using BuildingBricks.PM.Constants;
using BuildingBricks.PM.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

PrintBanner();

JsonSerializerOptions jsonSerializerOptions = BuildJsonSerializerOptions();
IConfiguration config = GetConfiguration();
string dataPath = GetDataPath();

using CosmosClient cosmosClient = new(config[ConfigurationKeys.CosmosUri], Environment.GetEnvironmentVariable(EnvironmentVariables.CosmosKey)!);
Database database = await ConnectToDatabaseAsync(config[ConfigurationKeys.PMMetadataContainerId]);

Container metadataContainer = await ConnectToContainerAsync(config[ConfigurationKeys.PMMetadataContainerId], config[ConfigurationKeys.PMMetadataPartitionKey]);
await LoadAvailabilitiesAsync();
await LoadThemesAsync();

await LoadMerchandiseAsync();

static void PrintBanner()
{
	Console.Clear();
	Console.ForegroundColor = ConsoleColor.Green;
	Console.WriteLine(@".____                     .___ __________                   .___             __          ");
	Console.WriteLine(@"|    |    _________     __| _/ \______   \_______  ____   __| _/_ __   _____/  |_  ______");
	Console.WriteLine(@"|    |   /  _ \__  \   / __ |   |     ___/\_  __ \/  _ \ / __ |  |  \_/ ___\   __\/  ___/");
	Console.WriteLine(@"|    |__(  <_> ) __ \_/ /_/ |   |    |     |  | \(  <_> ) /_/ |  |  /\  \___|  |  \___ \ ");
	Console.WriteLine(@"|_______ \____(____  /\____ |   |____|     |__|   \____/\____ |____/  \___  >__| /____  >");
	Console.WriteLine(@"        \/         \/      \/                                \/           \/          \/ ");
	Console.WriteLine();
	Console.WriteLine();
	Console.ResetColor();
}

static JsonSerializerOptions BuildJsonSerializerOptions()
	=> new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
		DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
		WriteIndented = true
	};

IConfiguration GetConfiguration()
{
	ConfigurationBuilder builder = new();
	builder.AddAzureAppConfiguration(Environment.GetEnvironmentVariable(EnvironmentVariables.AppConfig)!);
	return builder.Build();
}

static string GetDataPath()
{
	string? response;
	do
	{
		Console.Write("Path to data files: ");
		response = Console.ReadLine();
		if (!Directory.Exists(response))
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Invalid path");
			Console.Beep();
			Console.ResetColor();
			response = null;
		}
	} while (response is null);
	return response;
}

async Task<Database> ConnectToDatabaseAsync(string id)
{
	Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync(id);
	Console.WriteLine($"Database Connected:\t{database.Id}");
	return database;
}

async Task<Container> ConnectToContainerAsync(string id, string partitionKeyPath)
{
	Container container = await database.CreateContainerIfNotExistsAsync(id, partitionKeyPath);
	Console.WriteLine($"Container Connected:\t{container.Id}");
	return container;
}

async Task<Dictionary<int, T>> RetrieveMetadataByLegacyIdAsync<T>(string metadataType) where T : Metadata
{
	Dictionary<int, T> response = new();
	using FeedIterator<T> feed = metadataContainer.GetItemQueryIterator<T>($"SELECT * FROM metadata");
	while (feed.HasMoreResults)
	{
		FeedResponse<T> feedResponse = await feed.ReadNextAsync();
		foreach (T item in feedResponse)
		{
			if (item.MetadataType == metadataType)
				response.Add(item.LegacyId, item);
		}
	}
	return response;
}

IEnumerable<string> GetDirectoryFilePaths(string directoryName)
	=> Directory.EnumerateFiles($@"{dataPath}\{directoryName}");

async Task LoadAvailabilitiesAsync()
{
	Console.WriteLine("Loading availabilities");
	Dictionary<int, Availability> existingAvailabilities = await RetrieveMetadataByLegacyIdAsync<Availability>(MetadataTypeConstants.Availability);
	IEnumerable<string> filePaths = GetDirectoryFilePaths(MetadataTypeConstants.Availability);
	if (filePaths.Any())
	{
		foreach (string filePath in filePaths)
		{
			Availability? availability = JsonSerializer.Deserialize<Availability>(File.ReadAllText(filePath), jsonSerializerOptions);
			if (availability is not null)
			{
				availability.MetadataType = MetadataTypeConstants.Availability;
				availability.LegacyId = Convert.ToInt32(availability.Id);
				availability.Id = Guid.NewGuid().ToString();
				if (!existingAvailabilities.ContainsKey(availability.LegacyId))
				{
					Availability createdItem = await metadataContainer.CreateItemAsync(availability, new PartitionKey(MetadataTypeConstants.Availability));
					Console.WriteLine($"\t{createdItem.Id}\t{createdItem.Name}");
				}
			}
		}
	}
}

async Task LoadThemesAsync()
{
	Console.WriteLine("Loading themes");
	Dictionary<int, Availability> availabilities = await RetrieveMetadataByLegacyIdAsync<Availability>(MetadataTypeConstants.Availability);
	Dictionary<int, Theme> existingThemes = await RetrieveMetadataByLegacyIdAsync<Theme>(MetadataTypeConstants.Theme);
	foreach (string filePath in GetDirectoryFilePaths(MetadataTypeConstants.Theme))
	{
		Theme? theme = JsonSerializer.Deserialize<Theme>(File.ReadAllText(filePath), jsonSerializerOptions);
		if (theme is not null)
		{
			theme.MetadataType = MetadataTypeConstants.Theme;
			theme.LegacyId = Convert.ToInt32(theme.Id);
			theme.Id = Guid.NewGuid().ToString();
			foreach (ThemeMerchandise themeMerchandise in theme.Merchandises)
			{
				if (availabilities.TryGetValue(Convert.ToInt32(themeMerchandise.AvailabilityId), out Availability? availability) && availability is not null)
				{
					themeMerchandise.AvailabilityId = availability.Id;
					themeMerchandise.Availability = availability.Name;
				}
			}
			if (!existingThemes.ContainsKey(theme.LegacyId))
			{
				Theme createdItem = await metadataContainer.CreateItemAsync<Theme>(theme, new PartitionKey(MetadataTypeConstants.Theme));
				Console.WriteLine($"\t{createdItem.Id}\t{createdItem.Name}");
			}
		}
	}
}

async Task LoadMerchandiseAsync()
{
	Console.WriteLine("Loading merchandise");

	Dictionary<int, Availability> availabilities = await RetrieveMetadataByLegacyIdAsync<Availability>(MetadataTypeConstants.Availability);
	Dictionary<int, Theme> existingThemes = await RetrieveMetadataByLegacyIdAsync<Theme>(MetadataTypeConstants.Theme);

	Container productsByAvailabilityContainer = await ConnectToContainerAsync(config[ConfigurationKeys.PMProductsByAvailabilityContainerId], config[ConfigurationKeys.PMProductsByAvailabilityPartitionKey]);
	List<string> productsByAvailability = await RetrieveMerchandiseListAsync(productsByAvailabilityContainer);

	Container productsByThemeContainer = await ConnectToContainerAsync(config[ConfigurationKeys.PMProductsByThemeContainerId], config[ConfigurationKeys.PMProductsByThemePartitionKey]);
	List<string> productsByTheme = await RetrieveMerchandiseListAsync(productsByThemeContainer);

	foreach (string filePath in GetDirectoryFilePaths("Merchandise"))
	{
		Merchandise? merchandise = JsonSerializer.Deserialize<Merchandise>(File.ReadAllText(filePath), jsonSerializerOptions);
		if (merchandise is not null
			&& availabilities.TryGetValue(Convert.ToInt32(merchandise.AvailabilityId), out Availability? availability) && availability is not null
			&& existingThemes.TryGetValue(Convert.ToInt32(merchandise.ThemeId), out Theme? theme) && theme is not null)
		{
			merchandise.AvailabilityId = availability.Id;
			merchandise.ThemeId = theme.Id;
			if (!productsByAvailability.Contains(merchandise.Id))
			{
				Merchandise createdItem = await productsByAvailabilityContainer.CreateItemAsync(merchandise, new PartitionKey(merchandise.AvailabilityId));
				Console.WriteLine($"\t(Availability)\t{createdItem.Id}\t{createdItem.Name}");
			}
			if (!productsByTheme.Contains(merchandise.Id))
			{
				Merchandise createdItem = await productsByThemeContainer.CreateItemAsync(merchandise, new PartitionKey(merchandise.ThemeId));
				Console.WriteLine($"\t(Theme)\t{createdItem.Id}\t{createdItem.Name}");
			}
		}
	}
}

async Task<List<string>> RetrieveMerchandiseListAsync(Container container)
{
	List<string> response = new();
	using FeedIterator<Merchandise> feed = container.GetItemQueryIterator<Merchandise>($"SELECT * FROM merchandise");
	while (feed.HasMoreResults)
	{
		FeedResponse<Merchandise> feedResponse = await feed.ReadNextAsync();
		foreach (Merchandise item in feedResponse)
			response.Add(item.Id);
	}
	return response;
}

using BuildingBricks.Core;
using BuildingBricks.Product.Models;
using BuildingBricks.Product.Services;
using Microsoft.Azure.Cosmos;
using System.Text.Json;
using System.Text.Json.Serialization;

PrintBanner();

JsonSerializerOptions jsonSerializerOptions = BuildJsonSerializerOptions();
string dataPath = GetDataPath();
ConfigServices configServices = new("appConfigEndpoint", "Development");

using CosmosClient cosmosClient = new(configServices.CosmosUri, configServices.CosmosKey);
Database database = ConnectToDatabaseAsync(configServices.ProductCosmosDatabaseId);

Container metadataContainer = await ConnectToContainerAsync(configServices.ProductMetadataContainerId, configServices.ProductMetadataPartitionKey);
AvailabilityServices availabilityServices = new(configServices, metadataContainer);
ThemeServices themeServices = new(configServices, metadataContainer);
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

Database ConnectToDatabaseAsync(string id)
{
	Database database = cosmosClient.GetDatabase(id);
	Console.WriteLine($"Database Connected:\t{database.Id}");
	return database;
}

async Task<Container> ConnectToContainerAsync(string id, string partitionKeyPath)
{
	Container container = await database.CreateContainerIfNotExistsAsync(id, partitionKeyPath);
	Console.WriteLine($"Container Connected:\t{container.Id}");
	return container;
}

IEnumerable<string> GetDirectoryFilePaths(string directoryName) => Directory.EnumerateFiles($@"{dataPath}\{directoryName}");

async Task LoadAvailabilitiesAsync()
{
	Console.WriteLine("Loading availabilities");
	Dictionary<int, Availability> existingAvailabilities = await availabilityServices.GetDictionaryAsync();
	IEnumerable<string> filePaths = GetDirectoryFilePaths(BuildingBricks.Product.Constants.MetadataType.Availability);
	if (filePaths.Any())
	{
		foreach (string filePath in filePaths)
		{
			Availability? availability = JsonSerializer.Deserialize<Availability>(File.ReadAllText(filePath), jsonSerializerOptions);
			if (availability is not null)
			{
				existingAvailabilities.TryGetValue(Convert.ToInt32(availability.Id), out Availability? existingAvailability);
				availability.MetadataType = BuildingBricks.Product.Constants.MetadataType.Availability;
				availability.LegacyId = Convert.ToInt32(availability.Id);
				availability.Id = existingAvailability?.Id ?? Guid.NewGuid().ToString();
				Availability upsertedItem = await availabilityServices.UpsertAsync(availability);
				Console.WriteLine($"\t{upsertedItem.Id}\t{upsertedItem.Name}");
			}
		}
	}
}

async Task LoadThemesAsync()
{
	Console.WriteLine("Loading themes");
	Dictionary<int, Theme> existingThemes = await themeServices.GetDictionaryAsync();
	IEnumerable<string> filePaths = GetDirectoryFilePaths(BuildingBricks.Product.Constants.MetadataType.Theme);
	if (filePaths.Any())
	{
		foreach (string filePath in filePaths)
		{
			Theme? theme = JsonSerializer.Deserialize<Theme>(File.ReadAllText(filePath), jsonSerializerOptions);
			if (theme is not null)
			{
				existingThemes.TryGetValue(Convert.ToInt32(theme.Id), out Theme? existingTheme);
				theme.MetadataType = BuildingBricks.Product.Constants.MetadataType.Theme;
				theme.LegacyId = Convert.ToInt32(theme.Id);
				theme.Id = existingTheme?.Id ?? Guid.NewGuid().ToString();
				Theme upsertedItem = await themeServices.UpsertAsync(theme);
				Console.WriteLine($"\t{upsertedItem.Id}\t{upsertedItem.Name}");
			}
		}
	}
}

async Task LoadMerchandiseAsync()
{
	Console.WriteLine("Loading merchandise");
	Container merchandiseContainer = await ConnectToContainerAsync(configServices.ProductMerchandiseContainerId, configServices.ProductMerchandisePartitionKey);
	MerchandiseServices merchandiseServices = new(merchandiseContainer);
	Dictionary<int, Availability> availabilities = await availabilityServices.GetDictionaryAsync();
	Dictionary<int, Theme> themes = await themeServices.GetDictionaryAsync();
	IEnumerable<string> filePaths = GetDirectoryFilePaths("Merchandise");
	if (filePaths.Any())
	{
		foreach (string filePath in filePaths)
		{
			Merchandise? merchandise = JsonSerializer.Deserialize<Merchandise>(File.ReadAllText(filePath), jsonSerializerOptions);
			if (merchandise is not null
				&& availabilities.TryGetValue(Convert.ToInt32(merchandise.AvailabilityId), out Availability? availability) && availability is not null
				&& themes.TryGetValue(Convert.ToInt32(merchandise.ThemeId), out Theme? theme) && theme is not null)
			{
				merchandise.AvailabilityId = availability.Id;
				merchandise.ThemeId = theme.Id;
				Merchandise upsertedItem = await merchandiseServices.UpsertAsync(merchandise);
				Console.WriteLine($"\t{upsertedItem.Id}\t{upsertedItem.Name}");
			}
		}
	}
}
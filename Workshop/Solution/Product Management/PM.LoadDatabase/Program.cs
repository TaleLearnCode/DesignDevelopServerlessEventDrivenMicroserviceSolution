using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Identity;
using BuildingBricks.PM.Constants;
using BuildingBricks.PM.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using JsonSerializer = System.Text.Json.JsonSerializer;

JsonSerializerOptions jsonSerializerOptions = new()
{
  PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
  DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
  DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
  WriteIndented = true
};

PrintBanner();
DefaultAzureCredential defaultAzureCredential = new();
IConfiguration config = GetConfiguration();
string dataPath = GetDataPath();
using CosmosClient cosmosClient = new(config[ConfigurationKeys.CosmosUri], config[ConfigurationKeys.CosmosKey]);
Database database = await ConnectToDatabaseAsync(config[ConfigurationKeys.PMMetadataContainerId]);

Container metadataContainer = await ConnectToContainerAsync(config[ConfigurationKeys.PMMetadataContainerId], config[ConfigurationKeys.PMMetadataPartitionKey]);
await LoadAvailabilitiesAsync();


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

IConfiguration GetConfiguration()
{
  ConfigurationBuilder builder = new();


  //AzureAppConfigurationOptions options = new();
  //options.Connect(Environment.GetEnvironmentVariable("OrderProcessingSystem-AppConfig"));

  //AzureAppConfigurationKeyVaultOptions keyVaultOptions = new();
  //keyVaultOptions.SetCredential(defaultAzureCredential);
  //keyVaultOptions.SetSecretRefreshInterval(TimeSpan.FromHours(3));
  ////options.ConfigureKeyVault(keyVaultOptions);

  //options.ConfigureKeyVault(kv =>
  //{
  //  kv.SetCredential(defaultAzureCredential);
  //  kv.SetSecretRefreshInterval(TimeSpan.FromHours(3));
  //});

  //builder.AddAzureAppConfiguration(Environment.GetEnvironmentVariable("OrderProcessingSystem-AppConfig"));

  builder.AddAzureAppConfiguration(options =>
  {
    options.Connect(Environment.GetEnvironmentVariable("OrderProcessingSystem-AppConfig")).ConfigureKeyVault(kv =>
    {
      kv.SetCredential(defaultAzureCredential);
      kv.SetSecretRefreshInterval(TimeSpan.FromHours(3));
    });
  });







  IConfigurationRoot config = builder.Build();
  return config;
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

async Task LoadAvailabilitiesAsync()
{
  Console.WriteLine("Loading availabilities");
  Dictionary<int, Availability> existingAvailabilities = await RetrieveMetadataAsync<Availability>(MetadataTypeConstants.Availability);
  IEnumerable<string> filePaths = Directory.EnumerateFiles($@"{dataPath}\{MetadataTypeConstants.Availability}");
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
          Availability createdItem = await metadataContainer.CreateItemAsync<Availability>(
            item: availability,
            partitionKey: new PartitionKey("Availability")
            );
          Console.WriteLine($"Created item:\t{createdItem.Id}\t[{createdItem.Name}]");
        }

      }
    }
  }
}

async Task<Dictionary<int, T>> RetrieveMetadataAsync<T>(string metadataType) where T : Metadata
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
// Ignore Spelling: Sql app

using Azure.Identity;
using BuildingBricks.Core.Enumerations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace BuildingBricks.Core;

public partial class ConfigServices
{

	private readonly IConfigurationRoot _config;

	public ConfigServices()
	{
		_config = GetConfiguration("https://appcs-eda-prototype-use.azconfig.io", "Development");
	}

	public ConfigServices(string appConfigEndpoint)
	{
		_config = GetConfiguration(appConfigEndpoint, "Development");
	}

	public ConfigServices(string appConfigEndpoint, string environment)
	{
		_config = GetConfiguration(appConfigEndpoint, environment);
	}

	private static IConfigurationRoot GetConfiguration(string appConfigEndpoint, string environment)
	{
		ConfigurationBuilder builder = new();
		DefaultAzureCredential defaultAzureCredential = new();
		builder.AddAzureAppConfiguration(options =>
		{
			options.Connect(new Uri(appConfigEndpoint), defaultAzureCredential)
			.Select(KeyFilter.Any, LabelFilter.Null)
			.Select(KeyFilter.Any, environment)
			.ConfigureKeyVault(kv =>
			{
				kv.SetCredential(defaultAzureCredential);
			});
		});
		IConfigurationRoot configurationRoot = builder.Build();
		return configurationRoot;
	}

#pragma warning disable CS8603 // Possible null reference return.
	private string GetConfigValue(string key) => _config[key];
#pragma warning restore CS8603 // Possible null reference return.

	private string AzureSqlConnectionString(string catalog)
		=> $"Data Source={AzureSqlDataSource};Initial Catalog={catalog};User ID={AzureSqlUserId};Password={AzureSqlPassword}";

	public string AzureSqlConnectionString(BuildingBrickSystem buildingBrickSystem)
		=> buildingBrickSystem switch
		{
			BuildingBrickSystem.Core => AzureSqlConnectionString(CoreAzureSqlCatalog),
			BuildingBrickSystem.Inventory => AzureSqlConnectionString(InventoryAzureSqlCatalog),
			BuildingBrickSystem.Notice => AzureSqlConnectionString(NoticeAzureSqlCatalog),
			BuildingBrickSystem.Purchase => AzureSqlConnectionString(PurchaseAzureSqlCatalog),
			BuildingBrickSystem.Shipping => AzureSqlConnectionString(ShippingAzureSqlCatalog),
			_ => throw new ArgumentOutOfRangeException(nameof(buildingBrickSystem))
		};

}
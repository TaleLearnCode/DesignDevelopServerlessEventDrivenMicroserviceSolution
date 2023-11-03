// Ignore Spelling: Metadata

namespace BuildingBricks.Core;

public partial class ConfigServices
{

	private const string _Product_CosmosDatabaseId = "Product:Cosmos:DatabaseId";

	private const string _Product_MetadataContainerId = "Product:Cosmos:Metadata:ContainerId";
	private const string _Product_MetadataPartitionKey = "Product:Cosmos:Metadata:PartitionKey";

	private const string _Product_MerchandiseContainerId = "Product:Cosmos:Merchandise:ContainerId";
	private const string _Product_MerchandisePartitionKey = "Product:Cosmos:Merchandise:PartitionKey";

	private const string _Product_MerchandiseByAvailabilityContainerId = "Product:Cosmos:MerchandiseByAvailability:ContainerId";
	private const string _Product_MerchandiseByAvailabilityPartitionKey = "Product:Cosmos:MerchandiseByAvailability:PartitionKey";

	private const string _Product_MerchandiseByThemeContainerId = "Product:Cosmos:MerchandiseByTheme:ContainerId";
	private const string _Product_MerchandiseByThemePartitionKey = "Product:Cosmos:MerchandiseByTheme:PartitionKey";

	private const string _Product_InventoryUpdatedEventHub_ConnectionString = "Product:EventHubs:InventoryUpdated:ConnectionString";

	public string ProductCosmosDatabaseId => GetConfigValue(_Product_CosmosDatabaseId);

	public string ProductMetadataContainerId => GetConfigValue(_Product_MetadataContainerId);

	public string ProductMetadataPartitionKey => GetConfigValue(_Product_MetadataPartitionKey);

	public string ProductMerchandiseContainerId => GetConfigValue(_Product_MerchandiseContainerId);

	public string ProductMerchandisePartitionKey => GetConfigValue(_Product_MerchandisePartitionKey);

	public string ProductsByAvailabilityContainerId => GetConfigValue(_Product_MerchandiseByAvailabilityContainerId);

	public string ProductsByAvailabilityPartitionKey => GetConfigValue(_Product_MerchandiseByAvailabilityPartitionKey);

	public string ProductsByThemeContainerId => GetConfigValue(_Product_MerchandiseByThemeContainerId);

	public string ProductsByThemePartitionKey => GetConfigValue(_Product_MerchandiseByThemePartitionKey);

	public string ProductInventoryUpdatedEventHubConnectionString => GetConfigValue(_Product_InventoryUpdatedEventHub_ConnectionString);

}
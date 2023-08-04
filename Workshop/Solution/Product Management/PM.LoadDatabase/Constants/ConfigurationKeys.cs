namespace BuildingBricks.PM.Constants;

public static class ConfigurationKeys
{
  public const string CosmosKey = "Cosmos:Key";
  public const string CosmosUri = "Cosmos:Uri";
  public const string PMCosmosDatabaseId = "ProductManagement:Cosmos:DatabaseId";
  public const string PMMetadataContainerId = "ProductManagement:Cosmos:Metadata:ContainerId";
  public const string PMMetadataPartitionKey = "ProductManagement:Cosmos:Metadata:PartitionKey";
  public const string PMProductsByAvailabilityContainerId = "ProductManagement:Cosmos:ProductsByAvailability:ContainerId";
  public const string PMProductsByAvailabilityPartitionKey = "ProductManagement:Cosmos:ProductsByAvailability:PartitionKey";
  public const string PMProductsByThemeContainerId = "ProductManagement:Cosmos:ProductsByTheme:ContainerId";
  public const string PMProductsByThemePartitionKey = "ProductManagement:Cosmos:ProductsByTheme:PartitionKey";
}
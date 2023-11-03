// Ignore Spelling: Sql

namespace BuildingBricks.Core;

public partial class ConfigServices
{

	private const string _Purchase_AzureSqlCatalog = "Purchase:AzureSql:Catalog";
	private const string _Purchase_ServiceBus_PlaceOrder_ConnectionString = "Purchase:ServiceBus:PlaceOrder:ConnectionString";

	private const string _Purchase_PlaceOrderServiceBusConnectionString = "Purchase:ServiceBus:PlaceOrder:ConnectionString";
	private const string _Purchase_PlaceOrderServiceBusQueueName = "Purchase:ServiceBus:PlaceOrder:QueueName";

	private const string _Purchase_PlaceOrderEventHubConnectionString = "Purchase:EventHubs:PlaceOrder:ConnectionString";

	public string PurchaseAzureSqlCatalog => GetConfigValue(_Purchase_AzureSqlCatalog);

	public string PurchaseServiceBusPlaceOrderConnectionString => GetConfigValue(_Purchase_ServiceBus_PlaceOrder_ConnectionString);

	public string PurchaseServiceBusPlaceOrderServiceBusQueueName => GetConfigValue(_Purchase_PlaceOrderServiceBusQueueName);

	public string PurchasePlaceOrderEventHubConnectionString => GetConfigValue(_Purchase_PlaceOrderEventHubConnectionString);

}
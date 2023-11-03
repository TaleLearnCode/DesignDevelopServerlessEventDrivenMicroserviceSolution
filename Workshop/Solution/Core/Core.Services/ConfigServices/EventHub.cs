namespace BuildingBricks.Core;

public partial class ConfigServices
{

	private const string _EventHubs_InventoryReserved = "EventHubs:InventoryReserved";
	private const string _EventHubs_InventoryUpdated = "EventHubs:InventoryUpdated";

	public string EventHubsInventoryReserved => GetConfigValue(_EventHubs_InventoryReserved);

	public string EventHubsInventoryUpdated => GetConfigValue(_EventHubs_InventoryUpdated);

}
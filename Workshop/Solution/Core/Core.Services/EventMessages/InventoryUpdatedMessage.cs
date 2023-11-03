namespace BuildingBricks.Core.EventMessages;

public class InventoryUpdatedMessage
{
	public string ProductId { get; set; } = null!;
	public int InventoryOnHand { get; set; }
	public int InventoryReserved { get; set; }
	public int InventoryAvailable { get; set; }
	public DateTime LastUpdate { get; set; }
}
namespace BuildingBricks.EventMessages;

public class InventoryReservedMessage
{
	public int CustomerId { get; set; }
	public string OrderId { get; set; } = null!;
	public string ProductId { get; set; } = null!;
	public string ProductName { get; set; } = null!;
	public int QuantityOnHand { get; set; }
	public bool Backordered { get; set; }
}
namespace BuildingBlocks.Core.EventMessage;

public class OrderItemMessage
{
	public string OrderId { get; set; } = null!;
	public int OrderItemId { get; set; }
	public string ProductId { get; set; } = null!;
	public int Quantity { get; set; }
}
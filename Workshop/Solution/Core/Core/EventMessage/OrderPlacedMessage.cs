namespace BuildingBlocks.Core.EventMessage;

public class OrderPlacedMessage
{
	public string OrderId { get; init; } = null!;
	public int CustomerId { get; init; }
	public List<OrderItemMessage> Items { get; init; } = new List<OrderItemMessage>();
}
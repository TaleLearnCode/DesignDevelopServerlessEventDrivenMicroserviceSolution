using BuildingBricks.Core.EventMessages;

namespace BuildingBricks.EventMessages;

public class OrderPlacedMessage
{
	public string PurchaseId { get; init; } = null!;
	public int CustomerId { get; init; }
	public List<ProductPurchasedMessage> Items { get; init; } = new List<ProductPurchasedMessage>();
}
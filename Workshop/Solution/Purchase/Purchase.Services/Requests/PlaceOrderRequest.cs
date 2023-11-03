namespace BuildingBricks.Purchase.Requests;

public class PlaceOrderRequest
{
	public int CustomerId { get; set; }
	public List<PlaceOrderItem> Items { get; set; } = new();
}
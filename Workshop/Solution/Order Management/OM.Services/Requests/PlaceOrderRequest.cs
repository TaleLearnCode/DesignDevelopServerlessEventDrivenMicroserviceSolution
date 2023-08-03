namespace BuildingBricks.OM.Requests;

public class PlaceOrderRequest
{
	public int CustomerId { get; set; }
	public List<PlaceOrderItem> Items { get; set; } = new();
}
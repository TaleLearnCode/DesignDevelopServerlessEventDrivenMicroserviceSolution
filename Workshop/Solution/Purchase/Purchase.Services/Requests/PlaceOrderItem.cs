namespace BuildingBricks.Purchase.Requests;

public class PlaceOrderItem
{
	public string ProductId { get; set; } = null!;
	public int Quantity { get; set; }
}
#nullable disable

namespace BuildingBricks.Shipping.Models;

public partial class OrderItem
{

	public int OrderItemId { get; set; }

	public string CustomerOrderId { get; set; }

	public string ProductId { get; set; }

	public virtual CustomerPurchase CustomerOrder { get; set; }

	public virtual Product Product { get; set; }

}
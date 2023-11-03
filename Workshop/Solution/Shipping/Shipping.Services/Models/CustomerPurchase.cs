#nullable disable

namespace BuildingBricks.Shipping.Models;

public partial class CustomerPurchase
{

	public string CustomerPurchaseId { get; set; }

	public int CustomerId { get; set; }

	public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

	public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

}
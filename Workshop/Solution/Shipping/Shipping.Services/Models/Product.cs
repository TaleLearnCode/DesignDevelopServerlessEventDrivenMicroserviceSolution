#nullable disable

namespace BuildingBricks.Shipping.Models;

public partial class Product
{

	public string ProductId { get; set; }

	public string ProductName { get; set; }

	public int ProductWeight { get; set; }

	public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

}
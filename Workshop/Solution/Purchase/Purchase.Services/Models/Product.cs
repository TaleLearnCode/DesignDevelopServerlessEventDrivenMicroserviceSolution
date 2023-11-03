#nullable disable

namespace BuildingBricks.Purchase.Models;

/// <summary>
/// Represents a product in inventory.
/// </summary>
public partial class Product
{

	/// <summary>
	/// Identifier for the product.
	/// </summary>
	public string ProductId { get; set; }

	/// <summary>
	/// Name for the product.
	/// </summary>
	public string ProductName { get; set; }

	/// <summary>
	/// The current price for the product.
	/// </summary>
	public decimal Price { get; set; }

	public virtual ICollection<PurchaseLineItem> PurchaseLineItems { get; set; } = new List<PurchaseLineItem>();

}
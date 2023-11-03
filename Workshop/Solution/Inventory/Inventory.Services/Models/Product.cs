#nullable disable

namespace BuildingBricks.Inventory.Models;

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

	public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

}
#nullable disable

namespace BuildingBricks.Inventory.Models;

/// <summary>
/// Represents a type of action taken on the inventory of a product.
/// </summary>
public partial class InventoryAction
{

	/// <summary>
	/// Identifier for the inventory action.
	/// </summary>
	public int InventoryActionId { get; set; }

	/// <summary>
	/// Name for the inventory action.
	/// </summary>
	public string InventoryActionName { get; set; }

	public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

}
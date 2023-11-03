#nullable disable

namespace BuildingBricks.Inventory.Models;

/// <summary>
/// Represents the inventory status of a product.
/// </summary>
public partial class InventoryTransaction
{

	/// <summary>
	/// Identifier for the product inventory transaction.
	/// </summary>
	public int InventoryId { get; set; }

	/// <summary>
	/// Identifier for the product.
	/// </summary>
	public string ProductId { get; set; }

	/// <summary>
	/// Identifier for the associated product inventory action.
	/// </summary>
	public int InventoryActionId { get; set; }

	/// <summary>
	/// The date and time of the product inventory transaction.
	/// </summary>
	public DateTime ActionDateTime { get; set; }

	/// <summary>
	/// The number of items to credit the product inventory by.
	/// </summary>
	public int InventoryCredit { get; set; }

	/// <summary>
	/// The number of items to debit the product inventory by.
	/// </summary>
	public int InventoryDebit { get; set; }

	/// <summary>
	/// The number of items to put on product inventory hold.
	/// </summary>
	public int InventoryReserve { get; set; }

	/// <summary>
	/// Identifier for any associated product.
	/// </summary>
	public string OrderNumber { get; set; }

	public virtual InventoryAction InventoryAction { get; set; }

	public virtual Product Product { get; set; }

}
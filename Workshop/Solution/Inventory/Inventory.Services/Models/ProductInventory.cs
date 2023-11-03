#nullable disable

namespace BuildingBricks.Inventory.Models;

public partial class ProductInventory
{

	public string ProductId { get; set; }

	public string ProductName { get; set; }

	public int? ProductInventoryOnHand { get; set; }

	public int? ReservedCount { get; set; }

}
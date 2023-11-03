#nullable disable

namespace BuildingBricks.Purchase.Models;

/// <summary>
/// Represents a line item within a purchase.
/// </summary>
public partial class PurchaseLineItem
{

	/// <summary>
	/// Identifier for the purchase line item.
	/// </summary>
	public int PurchaseLineItemId { get; set; }

	/// <summary>
	/// Identifier for the associated customer purchase.
	/// </summary>
	public string CustomerPurchaseId { get; set; }

	/// <summary>
	/// Identifier for the associated product.
	/// </summary>
	public string ProductId { get; set; }

	/// <summary>
	/// The quantity of product being purchased.
	/// </summary>
	public int Quantity { get; set; }

	/// <summary>
	/// The purchase price of the product.
	/// </summary>
	public decimal ProductPrice { get; set; }

	/// <summary>
	/// Identifier of the current status for the line item.
	/// </summary>
	public int PurchaseStatusId { get; set; }

	public DateTime DateTimeAdded { get; set; }

	public virtual CustomerPurchase CustomerPurchase { get; set; }

	public virtual Product Product { get; set; }

	public virtual PurchaseStatus PurchaseStatus { get; set; }

}
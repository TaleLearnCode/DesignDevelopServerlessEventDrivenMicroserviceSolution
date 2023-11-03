#nullable disable

namespace BuildingBricks.Purchase.Models;

/// <summary>
/// Represents a purchase by a customer.
/// </summary>
public partial class CustomerPurchase
{

	/// <summary>
	/// Identifier for the customer purchase.
	/// </summary>
	public string CustomerPurchaseId { get; set; }

	/// <summary>
	/// Identifier for the associated customer.
	/// </summary>
	public int CustomerId { get; set; }

	/// <summary>
	/// Identifier for the current purchase status.
	/// </summary>
	public int PurchaseStatusId { get; set; }

	/// <summary>
	/// The UTC date and time of the purchase.
	/// </summary>
	public DateTime PurchaseDateTime { get; set; }

	/// <summary>
	/// The UTC date and time of when the product(s) are reserved for the purchase.
	/// </summary>
	public DateTime? ReserveDateTime { get; set; }

	/// <summary>
	/// The UTC date and time of when the purchase is shipped.
	/// </summary>
	public DateTime? ShipDateTime { get; set; }

	/// <summary>
	/// The UTC date and time of when the purchase is completed (shipment received).
	/// </summary>
	public DateTime? CompleteDateTime { get; set; }

	public virtual Customer Customer { get; set; }

	public virtual ICollection<PurchaseLineItem> PurchaseLineItems { get; set; } = new List<PurchaseLineItem>();

	public virtual PurchaseStatus PurchaseStatus { get; set; }

}
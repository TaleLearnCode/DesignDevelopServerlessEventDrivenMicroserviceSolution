#nullable disable

namespace BuildingBricks.Purchase.Models;

/// <summary>
/// Represents the status of a purchase.
/// </summary>
public partial class PurchaseStatus
{

	/// <summary>
	/// Identifier for the purchase status.
	/// </summary>
	public int PurchaseStatusId { get; set; }

	/// <summary>
	/// Name for the purchase status.
	/// </summary>
	public string PurchaseStatusName { get; set; }

	public virtual ICollection<CustomerPurchase> CustomerPurchases { get; set; } = new List<CustomerPurchase>();

	public virtual ICollection<PurchaseLineItem> PurchaseLineItems { get; set; } = new List<PurchaseLineItem>();

}
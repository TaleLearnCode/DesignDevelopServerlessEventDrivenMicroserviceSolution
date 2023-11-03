#nullable disable

namespace BuildingBricks.Shipping.Models;

/// <summary>
/// Represents a shipment of product to a customer.
/// </summary>
public partial class Shipment
{

	/// <summary>
	/// Identifier for the shipment.
	/// </summary>
	public int ShipmentId { get; set; }

	/// <summary>
	/// Identifier for the associated shipment status.
	/// </summary>
	public int ShipmentStatusId { get; set; }

	/// <summary>
	/// Identifier for the associated customer purchase.
	/// </summary>
	public string CustomerPurchaseId { get; set; }

	public virtual CustomerPurchase CustomerPurchase { get; set; }

	public virtual ShipmentStatus ShipmentStatus { get; set; }

	public virtual ICollection<ShipmentStatusDetail> ShipmentStatusDetails { get; set; } = new List<ShipmentStatusDetail>();

}
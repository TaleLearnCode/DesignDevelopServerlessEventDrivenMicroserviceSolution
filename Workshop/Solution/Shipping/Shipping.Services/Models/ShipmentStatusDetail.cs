#nullable disable

namespace BuildingBricks.Shipping.Models;

/// <summary>
/// Represents the status for a shipment.
/// </summary>
public partial class ShipmentStatusDetail
{

	/// <summary>
	/// Identifier for the shipment status detail record.
	/// </summary>
	public int ShipmentStatusDetailId { get; set; }

	/// <summary>
	/// Identifier for the associated shipment record.
	/// </summary>
	public int ShipmentId { get; set; }

	/// <summary>
	/// Identifier for the associated shipment status.
	/// </summary>
	public int ShipmentStatusId { get; set; }

	/// <summary>
	/// The UTC date/time of the shipment status.
	/// </summary>
	public DateTime StatusDateTime { get; set; }

	public virtual Shipment Shipment { get; set; }

	public virtual ShipmentStatus ShipmentStatus { get; set; }

}
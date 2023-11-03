#nullable disable

namespace BuildingBricks.Shipping.Models;

/// <summary>
/// Represents the status for a shipment.
/// </summary>
public partial class ShipmentStatus
{

	/// <summary>
	/// Identifier for the shipment status record.
	/// </summary>
	public int ShipmentStatusId { get; set; }

	/// <summary>
	/// Name of the shipment status.
	/// </summary>
	public string ShipmentStatusName { get; set; }

	public virtual ICollection<ShipmentStatusDetail> ShipmentStatusDetails { get; set; } = new List<ShipmentStatusDetail>();

	public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

}
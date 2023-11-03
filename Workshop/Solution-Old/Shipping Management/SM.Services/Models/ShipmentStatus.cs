using System;
using System.Collections.Generic;

namespace BuildingBricks.SM.Models
{
    public partial class ShipmentStatus
    {
        public ShipmentStatus()
        {
            ShipmentStatusDetails = new HashSet<ShipmentStatusDetail>();
            Shipments = new HashSet<Shipment>();
        }

        public int ShipmentStatusId { get; set; }
        public string ShipmentStatusName { get; set; } = null!;

        public virtual ICollection<ShipmentStatusDetail> ShipmentStatusDetails { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}

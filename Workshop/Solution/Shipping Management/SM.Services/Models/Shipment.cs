using System;
using System.Collections.Generic;

namespace BuildingBricks.SM.Models
{
    public partial class Shipment
    {
        public Shipment()
        {
            ShipmentStatusDetails = new HashSet<ShipmentStatusDetail>();
        }

        public int ShipmentId { get; set; }
        public int ShipmentStatusId { get; set; }
        public string CustomerOrderId { get; set; } = null!;

        public virtual CustomerOrder CustomerOrder { get; set; } = null!;
        public virtual ShipmentStatus ShipmentStatus { get; set; } = null!;
        public virtual ICollection<ShipmentStatusDetail> ShipmentStatusDetails { get; set; }
    }
}

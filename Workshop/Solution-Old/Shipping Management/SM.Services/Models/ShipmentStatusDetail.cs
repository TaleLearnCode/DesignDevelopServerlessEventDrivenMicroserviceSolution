using System;
using System.Collections.Generic;

namespace BuildingBricks.SM.Models
{
    public partial class ShipmentStatusDetail
    {
        public int ShipmentStatusDetailId { get; set; }
        public int ShipmentId { get; set; }
        public int ShipmentStatusId { get; set; }
        public DateTime StatusDateTime { get; set; }

        public virtual Shipment Shipment { get; set; } = null!;
        public virtual ShipmentStatus ShipmentStatus { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace BuildingBricks.SM.Models
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            OrderItems = new HashSet<OrderItem>();
            Shipments = new HashSet<Shipment>();
        }

        public string CustomerOrderId { get; set; } = null!;
        public int CustomerId { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}

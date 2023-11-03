using System;
using System.Collections.Generic;

namespace BuildingBricks.OM.Models
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public string CustomerOrderId { get; set; } = null!;
        public int CustomerId { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public DateTime? ReserveDateTime { get; set; }
        public DateTime? ShipDateTime { get; set; }
        public DateTime? CompleteDateTime { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}

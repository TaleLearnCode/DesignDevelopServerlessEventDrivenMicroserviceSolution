using System;
using System.Collections.Generic;

namespace BuildingBricks.OM.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; } = null!;

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}

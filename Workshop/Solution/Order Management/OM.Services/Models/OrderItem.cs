using System;
using System.Collections.Generic;

namespace BuildingBricks.OM.Models
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public string CustomerOrderId { get; set; } = null!;
        public int OrderStatusId { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public DateTime? DateTimeModified { get; set; }

        public virtual CustomerOrder CustomerOrder { get; set; } = null!;
        public virtual OrderStatus OrderStatus { get; set; } = null!;
    }
}

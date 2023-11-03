using System;
using System.Collections.Generic;

namespace BuildingBricks.SM.Models
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public string CustomerOrderId { get; set; } = null!;
        public string ProductId { get; set; } = null!;

        public virtual CustomerOrder CustomerOrder { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}

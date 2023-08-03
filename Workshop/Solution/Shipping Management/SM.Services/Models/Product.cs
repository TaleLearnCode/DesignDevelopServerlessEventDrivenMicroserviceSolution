using System;
using System.Collections.Generic;

namespace BuildingBricks.SM.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public int ProductWeight { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}

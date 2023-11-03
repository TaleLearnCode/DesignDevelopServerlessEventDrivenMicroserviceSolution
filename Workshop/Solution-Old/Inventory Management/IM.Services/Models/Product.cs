using System;
using System.Collections.Generic;

namespace BuildingBricks.IM.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductInventories = new HashSet<ProductInventory>();
        }

        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;

        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
    }
}

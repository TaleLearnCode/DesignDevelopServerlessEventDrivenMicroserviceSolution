using System;
using System.Collections.Generic;

namespace BuildingBricks.IM.Models
{
    public partial class ProductInventoryAction
    {
        public ProductInventoryAction()
        {
            ProductInventories = new HashSet<ProductInventory>();
        }

        public int ProductInventoryActionId { get; set; }
        public string? ProductInventoryActionName { get; set; }

        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
    }
}

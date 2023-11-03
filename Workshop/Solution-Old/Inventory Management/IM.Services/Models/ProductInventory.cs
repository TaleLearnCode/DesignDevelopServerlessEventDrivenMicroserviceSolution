using System;
using System.Collections.Generic;

namespace BuildingBricks.IM.Models
{
    public partial class ProductInventory
    {
        public int ProductInventoryId { get; set; }
        public string ProductId { get; set; } = null!;
        public int ProductInventoryActionId { get; set; }
        public DateTime ActionDateTime { get; set; }
        public int InventoryCredit { get; set; }
        public int InventoryDebit { get; set; }
        public string? OrderNumber { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual ProductInventoryAction ProductInventoryAction { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace BuildingBricks.OM.Models
{
    public partial class Product
    {
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
    }
}

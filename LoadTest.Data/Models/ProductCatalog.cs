using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class ProductCatalog
    {
        public ProductCatalog()
        {
            Product = new HashSet<Product>();
        }

        public int ProductCatalogId { get; set; }
        public int ProductCatalogTypeId { get; set; }
        public string ProductCatalogName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Specification { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string Material { get; set; } = string.Empty;
        public DateTime InsertDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ProductCatalogType ProductCatalogType { get; set; } = null!;
        public virtual ICollection<Product> Product { get; set; }
    }
}
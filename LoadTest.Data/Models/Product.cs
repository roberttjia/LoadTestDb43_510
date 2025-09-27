using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductStock = new HashSet<ProductStock>();
            SellingAdjustment = new HashSet<SellingAdjustment>();
            PurchaseList = new HashSet<PurchaseList>();
            SellingList = new HashSet<SellingList>();
        }

        public int ProductId { get; set; }
        public int ProductCatalogId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Warranty { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public decimal SellingPrice { get; set; }
        public DateTime InsertDate { get; set; }
        
        public virtual ProductCatalog ProductCatalog { get; set; } = null!;
        public virtual ICollection<ProductStock> ProductStock { get; set; }
        public virtual ICollection<SellingAdjustment> SellingAdjustment { get; set; }
        public virtual ICollection<PurchaseList> PurchaseList { get; set; }
        public virtual ICollection<SellingList> SellingList { get; set; }
    }
}
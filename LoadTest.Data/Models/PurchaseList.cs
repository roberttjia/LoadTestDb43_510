using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class PurchaseList
    {
        public PurchaseList()
        {
            ProductStock = new HashSet<ProductStock>();
        }
        
        public int PurchaseListId { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Warranty { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public decimal SellingPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        
        public virtual Purchase Purchase { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<ProductStock> ProductStock { get; set; }
    }
}
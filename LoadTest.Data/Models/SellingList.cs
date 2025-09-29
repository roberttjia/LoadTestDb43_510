using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public partial class SellingList
    {
        public SellingList()
        {
            ProductStock = new HashSet<ProductStock>();
        }

        public int SellingListId { get; set; }
        public int SellingId { get; set; }
        public int ProductId { get; set; }
        public decimal SellingPrice { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Warranty { get; set; } = string.Empty;
        public decimal PurchasePrice { get; set; }
        
        public virtual Selling Selling { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<ProductStock> ProductStock { get; set; }
    }
}
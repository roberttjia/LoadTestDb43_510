using System;

namespace LoadTest.Data.Models
{
    public class SellingAdjustment
    {
        public int SellingAdjustmentId { get; set; }
        public int SellingId { get; set; }
        public int ProductId { get; set; }
        public int ProductStockId { get; set; }
        public string AdjustmentType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime AdjustmentDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string ApprovedBy { get; set; } = string.Empty;

        public virtual Selling Selling { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual ProductStock ProductStock { get; set; } = null!;
    }
}
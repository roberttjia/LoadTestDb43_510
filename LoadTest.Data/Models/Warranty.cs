using System;

namespace LoadTest.Data.Models
{
    public class Warranty
    {
        public int WarrantyId { get; set; }
        public int SellingId { get; set; }
        public int ProductStockId { get; set; }
        public string WarrantyType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Terms { get; set; } = string.Empty;
        public string Coverage { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string SerialNumber { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime InsertDate { get; set; }
        public string ContactInfo { get; set; } = string.Empty;
        public decimal WarrantyAmount { get; set; }
        public string Status { get; set; } = string.Empty;

        public virtual Selling Selling { get; set; } = null!;
        public virtual ProductStock ProductStock { get; set; } = null!;
    }
}
using System;

namespace LoadTest.Data.Models
{
    public class PurchasePaymentList
    {
        public int PurchasePaymentListId { get; set; }
        public int PurchasePaymentId { get; set; }
        public int PurchaseId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime InsertDate { get; set; }

        public virtual PurchasePayment PurchasePayment { get; set; } = null!;
        public virtual Purchase Purchase { get; set; } = null!;
    }
}
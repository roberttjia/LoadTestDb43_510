using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class PurchasePayment
    {
        public PurchasePayment()
        {
            PurchasePaymentList = new HashSet<PurchasePaymentList>();
        }

        public int PurchasePaymentId { get; set; }
        public int VendorId { get; set; }
        public int? AccountId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string TransactionId { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;

        public virtual Vendor Vendor { get; set; } = null!;
        public virtual Account? Account { get; set; }
        public virtual ICollection<PurchasePaymentList> PurchasePaymentList { get; set; }
    }
}
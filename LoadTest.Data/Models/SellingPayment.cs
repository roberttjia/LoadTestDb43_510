using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class SellingPayment
    {
        public SellingPayment()
        {
            SellingPaymentList = new HashSet<SellingPaymentList>();
        }

        public int SellingPaymentId { get; set; }
        public int CustomerId { get; set; }
        public int? AccountId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string TransactionId { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public decimal ServiceCharge { get; set; }
        public string Receipt { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string CheckNumber { get; set; } = string.Empty;

        public virtual Customer Customer { get; set; } = null!;
        public virtual Account? Account { get; set; }
        public virtual ICollection<SellingPaymentList> SellingPaymentList { get; set; }
    }
}
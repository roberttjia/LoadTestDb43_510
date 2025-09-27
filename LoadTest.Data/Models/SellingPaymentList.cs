using System;

namespace LoadTest.Data.Models
{
    public class SellingPaymentList
    {
        public int SellingPaymentListId { get; set; }
        public int SellingPaymentId { get; set; }
        public int SellingId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual SellingPayment SellingPayment { get; set; } = null!;
        public virtual Selling Selling { get; set; } = null!;
    }
}
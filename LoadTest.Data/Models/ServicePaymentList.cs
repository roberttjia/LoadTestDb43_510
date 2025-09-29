using System;

namespace LoadTest.Data.Models
{
    public class ServicePaymentList
    {
        public int ServicePaymentListId { get; set; }
        public int ServiceId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual Service Service { get; set; } = null!;
    }
}
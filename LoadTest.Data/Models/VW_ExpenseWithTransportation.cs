using System;

namespace LoadTest.Data.Models
{
    public class VW_ExpenseWithTransportation
    {
        public int Id { get; set; }
        public string ExpenseName { get; set; } = string.Empty;
        public decimal ExpenseAmount { get; set; }
        public decimal TransportationAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
    }
}
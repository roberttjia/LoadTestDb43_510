using System;

namespace LoadTest.Data.Models
{
    public class ExpenseTransportationList
    {
        public int ExpenseTransportationListId { get; set; }
        public int ExpenseTransportationId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual ExpenseTransportation ExpenseTransportation { get; set; } = null!;
    }
}
using System;

namespace LoadTest.Data.Models
{
    public class ExpenseFixed
    {
        public int ExpenseFixedId { get; set; }
        public string ExpenseName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
using System;

namespace LoadTest.Data.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public int ExpenseCategoryId { get; set; }
        public int? AccountId { get; set; }
        public string ExpenseName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string Receipt { get; set; } = string.Empty;
        public bool IsRecurring { get; set; }
        public string Notes { get; set; } = string.Empty;

        public virtual ExpenseCategory ExpenseCategory { get; set; } = null!;
        public virtual Account? Account { get; set; }
    }
}
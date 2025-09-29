using System;

namespace LoadTest.Data.Models
{
    public class SellingExpense
    {
        public int SellingExpenseId { get; set; }
        public int SellingId { get; set; }
        public decimal Expense { get; set; }
        public string ExpenseDescription { get; set; } = string.Empty;
        public DateTime InsertDateUtc { get; set; }
        public int? AccountId { get; set; }

        public virtual Selling Selling { get; set; } = null!;
        public virtual Account? Account { get; set; }
    }
}
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class ExpenseCategory
    {
        public ExpenseCategory()
        {
            Expense = new HashSet<Expense>();
        }

        public int ExpenseCategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Expense> Expense { get; set; }
    }
}
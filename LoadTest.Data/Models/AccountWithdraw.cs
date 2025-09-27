using System;

namespace LoadTest.Data.Models
{
    public class AccountWithdraw
    {
        public int AccountWithdrawId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime WithdrawDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string TransactionReference { get; set; } = string.Empty;

        public virtual Account Account { get; set; } = null!;
    }
}
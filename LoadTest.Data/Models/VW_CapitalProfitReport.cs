using System;

namespace LoadTest.Data.Models
{
    public class VW_CapitalProfitReport
    {
        public int Id { get; set; }
        public DateTime ReportDate { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalPurchases { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal GrossProfit { get; set; }
        public decimal NetProfit { get; set; }
        public decimal TotalAssets { get; set; }
        public decimal TotalLiabilities { get; set; }
        public decimal Capital { get; set; }
        public decimal ReturnOnInvestment { get; set; }
        public string Period { get; set; } = string.Empty;
        public string BusinessUnit { get; set; } = string.Empty;
        public decimal CashFlow { get; set; }
        public decimal Inventory { get; set; }
        public decimal AccountsReceivable { get; set; }
    }
}
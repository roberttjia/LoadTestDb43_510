using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class Selling
    {
        public Selling()
        {
            SellingAdjustment = new HashSet<SellingAdjustment>();
            SellingList = new HashSet<SellingList>();
            SellingPaymentList = new HashSet<SellingPaymentList>();
            SellingExpense = new HashSet<SellingExpense>();
            Warranty = new HashSet<Warranty>();
            ProductLog = new HashSet<ProductLog>();
            SellingPromiseDateMisses = new HashSet<SellingPromiseDateMiss>();
            SellingPaymentReturnRecord = new HashSet<SellingPaymentReturnRecord>();
        }

        public int SellingId { get; set; }
        public int RegistrationId { get; set; }
        public int CustomerId { get; set; }
        public int SellingSn { get; set; }
        public decimal SellingTotalPrice { get; set; }
        public decimal SellingDiscountAmount { get; set; }
        public decimal SellingDiscountPercentage { get; set; }
        public decimal SellingPaidAmount { get; set; }
        public decimal SellingReturnAmount { get; set; }
        public decimal SellingDueAmount { get; set; }
        public string SellingPaymentStatus { get; set; } = string.Empty;
        public DateTime SellingDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? PromisedPaymentDate { get; set; }
        public string SellingNotes { get; set; } = string.Empty;
        public decimal ServiceCharge { get; set; }
        public decimal ServiceCost { get; set; }
        public string ServiceChargeDescription { get; set; } = string.Empty;
        public decimal ExpenseTotal { get; set; }
        public decimal AccountTransactionCharge { get; set; }
        public decimal BuyingTotalPrice { get; set; }
        public decimal SellingAccountCost { get; set; }
        public decimal ServiceProfit { get; set; }
        public decimal SellingProfit { get; set; }
        public decimal SellingNetProfit { get; set; }
        public decimal GrandProfit { get; set; }
        public decimal PurchaseAdjustedAmount { get; set; }
        public string PurchaseDescription { get; set; } = string.Empty;
        public int? PurchaseId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Registration Registration { get; set; } = null!;
        public virtual Purchase? Purchase { get; set; }
        public virtual ICollection<SellingAdjustment> SellingAdjustment { get; set; }
        public virtual ICollection<SellingList> SellingList { get; set; }
        public virtual ICollection<SellingPaymentList> SellingPaymentList { get; set; }
        public virtual ICollection<SellingExpense> SellingExpense { get; set; }
        public virtual ICollection<Warranty> Warranty { get; set; }
        public virtual ICollection<ProductLog> ProductLog { get; set; }
        public virtual ICollection<SellingPromiseDateMiss> SellingPromiseDateMisses { get; set; }
        public virtual ICollection<SellingPaymentReturnRecord> SellingPaymentReturnRecord { get; set; }
    }
}
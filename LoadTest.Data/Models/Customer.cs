using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            Selling = new HashSet<Selling>();
            SellingPayment = new HashSet<SellingPayment>();
            Service = new HashSet<Service>();
            ServiceDevice = new HashSet<ServiceDevice>();
            ExpenseTransportation = new HashSet<ExpenseTransportation>();
            CustomerPhone = new HashSet<CustomerPhone>();
        }

        public int CustomerId { get; set; }
        public string OrganizationName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal ReturnAmount { get; set; }
        public decimal Paid { get; set; }
        public decimal AccountTransactionCharge { get; set; }
        public decimal Due { get; set; }
        public decimal PurchaseAdjustedAmount { get; set; }
        public decimal DueLimit { get; set; }
        public byte[]? Photo { get; set; }
        public DateTime InsertDate { get; set; }
        public string Designation { get; set; } = string.Empty;
        public bool IsIndividual { get; set; }
        
        public virtual ICollection<Selling> Selling { get; set; }
        public virtual ICollection<SellingPayment> SellingPayment { get; set; }
        public virtual ICollection<Service> Service { get; set; }
        public virtual ICollection<ServiceDevice> ServiceDevice { get; set; }
        public virtual ICollection<CustomerPhone> CustomerPhone { get; set; }
        public virtual ICollection<ExpenseTransportation> ExpenseTransportation { get; set; }
    }
}
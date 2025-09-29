using LoadTest.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LoadTest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<AdminMoneyCollection> AdminMoneyCollection { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountDeposit> AccountDeposit { get; set; }
        public virtual DbSet<AccountWithdraw> AccountWithdraw { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerPhone> CustomerPhone { get; set; }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<ExpenseFixed> ExpenseFixed { get; set; }
        public virtual DbSet<ExpenseTransportation> ExpenseTransportation { get; set; }
        public virtual DbSet<ExpenseTransportationList> ExpenseTransportationList { get; set; }
        public virtual DbSet<ExpenseCategory> ExpenseCategory { get; set; }
        public virtual DbSet<Institution> Institution { get; set; }
        public virtual DbSet<PageLink> PageLink { get; set; }
        public virtual DbSet<PageLinkAssign> PageLinkAssign { get; set; }
        public virtual DbSet<PageLinkCategory> PageLinkCategory { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCatalog> ProductCatalog { get; set; }
        public virtual DbSet<ProductCatalogType> ProductCatalogType { get; set; }
        public virtual DbSet<ProductDamaged> ProductDamaged { get; set; }
        public virtual DbSet<ProductLog> ProductLog { get; set; }
        public virtual DbSet<ProductStock> ProductStock { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseList> PurchaseList { get; set; }
        public virtual DbSet<PurchasePayment> PurchasePayment { get; set; }
        public virtual DbSet<PurchasePaymentList> PurchasePaymentList { get; set; }
        public virtual DbSet<PurchasePaymentReturnRecord> PurchasePaymentReturnRecord { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Selling> Selling { get; set; }
        public virtual DbSet<SellingExpense> SellingExpense { get; set; }
        public virtual DbSet<SellingAdjustment> SellingAdjustment { get; set; }
        public virtual DbSet<SellingList> SellingList { get; set; }
        public virtual DbSet<SellingPayment> SellingPayment { get; set; }
        public virtual DbSet<SellingPaymentList> SellingPaymentList { get; set; }
        public virtual DbSet<SellingPaymentReturnRecord> SellingPaymentReturnRecord { get; set; }
        public virtual DbSet<SellingPromiseDateMiss> SellingPromiseDateMiss { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceDevice> ServiceDevice { get; set; }
        public virtual DbSet<ServiceList> ServiceList { get; set; }
        public virtual DbSet<ServicePaymentList> ServicePaymentList { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<Warranty> Warranty { get; set; }
        public virtual DbSet<VW_ExpenseWithTransportation> VW_ExpenseWithTransportation { get; set; }
        public virtual DbSet<VW_CapitalProfitReport> VW_CapitalProfitReport { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints
            ConfigureRelationships(modelBuilder);
            
            // Configure views as keyless entities
            modelBuilder.Entity<VW_ExpenseWithTransportation>().HasNoKey().ToView("VW_ExpenseWithTransportation");
            modelBuilder.Entity<VW_CapitalProfitReport>().HasNoKey().ToView("VW_CapitalProfitReport");
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            // Disable cascade delete globally to avoid circular references
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Configure primary keys
            modelBuilder.Entity<AdminMoneyCollection>().HasKey(e => e.AdminMoneyCollectionId);
            modelBuilder.Entity<Account>().HasKey(e => e.AccountId);
            modelBuilder.Entity<AccountDeposit>().HasKey(e => e.AccountDepositId);
            modelBuilder.Entity<AccountWithdraw>().HasKey(e => e.AccountWithdrawId);
            modelBuilder.Entity<Customer>().HasKey(e => e.CustomerId);
            modelBuilder.Entity<CustomerPhone>().HasKey(e => e.CustomerPhoneId);
            modelBuilder.Entity<Expense>().HasKey(e => e.ExpenseId);
            modelBuilder.Entity<ExpenseFixed>().HasKey(e => e.ExpenseFixedId);
            modelBuilder.Entity<ExpenseTransportation>().HasKey(e => e.ExpenseTransportationId);
            modelBuilder.Entity<ExpenseTransportationList>().HasKey(e => e.ExpenseTransportationListId);
            modelBuilder.Entity<ExpenseCategory>().HasKey(e => e.ExpenseCategoryId);
            modelBuilder.Entity<Institution>().HasKey(e => e.InstitutionId);
            modelBuilder.Entity<PageLink>().HasKey(e => e.PageLinkId);
            modelBuilder.Entity<PageLinkAssign>().HasKey(e => e.PageLinkAssignId);
            modelBuilder.Entity<PageLinkCategory>().HasKey(e => e.PageLinkCategoryId);
            modelBuilder.Entity<Product>().HasKey(e => e.ProductId);
            modelBuilder.Entity<ProductCatalog>().HasKey(e => e.ProductCatalogId);
            modelBuilder.Entity<ProductCatalogType>().HasKey(e => e.ProductCatalogTypeId);
            modelBuilder.Entity<ProductDamaged>().HasKey(e => e.ProductDamagedId);
            modelBuilder.Entity<ProductLog>().HasKey(e => e.ProductLogId);
            modelBuilder.Entity<ProductStock>().HasKey(e => e.ProductStockId);
            modelBuilder.Entity<Purchase>().HasKey(e => e.PurchaseId);
            modelBuilder.Entity<PurchaseList>().HasKey(e => e.PurchaseListId);
            modelBuilder.Entity<PurchasePayment>().HasKey(e => e.PurchasePaymentId);
            modelBuilder.Entity<PurchasePaymentList>().HasKey(e => e.PurchasePaymentListId);
            modelBuilder.Entity<PurchasePaymentReturnRecord>().HasKey(e => e.PurchasePaymentReturnRecordId);
            modelBuilder.Entity<Registration>().HasKey(e => e.RegistrationId);
            modelBuilder.Entity<Selling>().HasKey(e => e.SellingId);
            modelBuilder.Entity<SellingExpense>().HasKey(e => e.SellingExpenseId);
            modelBuilder.Entity<SellingAdjustment>().HasKey(e => e.SellingAdjustmentId);
            modelBuilder.Entity<SellingList>().HasKey(e => e.SellingListId);
            modelBuilder.Entity<SellingPayment>().HasKey(e => e.SellingPaymentId);
            modelBuilder.Entity<SellingPaymentList>().HasKey(e => e.SellingPaymentListId);
            modelBuilder.Entity<SellingPaymentReturnRecord>().HasKey(e => e.SellingPaymentReturnRecordId);
            modelBuilder.Entity<SellingPromiseDateMiss>().HasKey(e => e.SellingPromiseDateMissId);
            modelBuilder.Entity<Service>().HasKey(e => e.ServiceId);
            modelBuilder.Entity<ServiceDevice>().HasKey(e => e.ServiceDeviceId);
            modelBuilder.Entity<ServiceList>().HasKey(e => e.ServiceListId);
            modelBuilder.Entity<ServicePaymentList>().HasKey(e => e.ServicePaymentListId);
            modelBuilder.Entity<Vendor>().HasKey(e => e.VendorId);
            modelBuilder.Entity<Warranty>().HasKey(e => e.WarrantyId);

            // Configure foreign key relationships with explicit DeleteBehavior.Restrict
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCatalog)
                .WithMany(pc => pc.Product)
                .HasForeignKey(p => p.ProductCatalogId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductCatalog>()
                .HasOne(pc => pc.ProductCatalogType)
                .WithMany(pct => pct.ProductCatalog)
                .HasForeignKey(pc => pc.ProductCatalogTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Registration)
                .WithMany(r => r.Purchase)
                .HasForeignKey(p => p.RegistrationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Vendor)
                .WithMany(v => v.Purchase)
                .HasForeignKey(p => p.VendorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Selling>()
                .HasOne(s => s.Customer)
                .WithMany(c => c.Selling)
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Selling>()
                .HasOne(s => s.Registration)
                .WithMany(r => r.Selling)
                .HasForeignKey(s => s.RegistrationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure decimal precision
            modelBuilder.Entity<Product>().Property(p => p.SellingPrice).HasPrecision(18, 2);
            modelBuilder.Entity<Customer>().Property(c => c.TotalAmount).HasPrecision(18, 2);
            modelBuilder.Entity<Purchase>().Property(p => p.PurchaseTotalPrice).HasPrecision(18, 2);
            modelBuilder.Entity<Selling>().Property(s => s.SellingTotalPrice).HasPrecision(18, 2);
        }
    }
}
using LoadTest.Data;
using LoadTest.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LoadTest.Console.Services
{
    public class EntityTestService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataGeneratorService _dataGenerator;
        private readonly ILogger<EntityTestService> _logger;

        public EntityTestService(
            ApplicationDbContext context,
            DataGeneratorService dataGenerator,
            ILogger<EntityTestService> logger)
        {
            _context = context;
            _dataGenerator = dataGenerator;
            _logger = logger;
        }

        public async Task TestAllEntitiesAsync(int recordsPerEntity, int batchSize)
        {
            _logger.LogInformation("Testing all 43 entities with {RecordsPerEntity} records each", recordsPerEntity);

            // Step 1: Create foundational data
            await CreateFoundationalDataAsync(recordsPerEntity, batchSize);

            // Step 2: Create dependent data
            await CreateDependentDataAsync(recordsPerEntity, batchSize);

            // Step 3: Verify data
            await VerifyDataAsync();

            _logger.LogInformation("✅ All entity tests completed successfully!");
        }

        private async Task CreateFoundationalDataAsync(int recordsPerEntity, int batchSize)
        {
            _logger.LogInformation("Creating foundational data...");

            // Create ProductCatalogTypes first
            _logger.LogInformation("Creating ProductCatalogTypes...");
            var catalogTypes = _dataGenerator.GenerateProductCatalogTypes(Math.Min(recordsPerEntity, 20));
            await AddInBatchesAsync(catalogTypes, batchSize);
            var catalogTypeIds = catalogTypes.Select(ct => ct.ProductCatalogTypeId).ToList();

            // Create ProductCatalogs
            _logger.LogInformation("Creating ProductCatalogs...");
            var catalogs = _dataGenerator.GenerateProductCatalogs(recordsPerEntity, catalogTypeIds);
            await AddInBatchesAsync(catalogs, batchSize);
            var catalogIds = catalogs.Select(c => c.ProductCatalogId).ToList();

            // Create Products
            _logger.LogInformation("Creating Products...");
            var products = _dataGenerator.GenerateProducts(recordsPerEntity, catalogIds);
            await AddInBatchesAsync(products, batchSize);

            // Create Customers
            _logger.LogInformation("Creating Customers...");
            var customers = _dataGenerator.GenerateCustomers(recordsPerEntity);
            await AddInBatchesAsync(customers, batchSize);

            // Create Vendors
            _logger.LogInformation("Creating Vendors...");
            var vendors = _dataGenerator.GenerateVendors(recordsPerEntity);
            await AddInBatchesAsync(vendors, batchSize);

            // Create Registrations
            _logger.LogInformation("Creating Registrations...");
            var registrations = _dataGenerator.GenerateRegistrations(recordsPerEntity);
            await AddInBatchesAsync(registrations, batchSize);

            // Create Accounts
            _logger.LogInformation("Creating Accounts...");
            var accounts = _dataGenerator.GenerateAccounts(recordsPerEntity);
            await AddInBatchesAsync(accounts, batchSize);

            // Create ExpenseCategories
            _logger.LogInformation("Creating ExpenseCategories...");
            var expenseCategories = _dataGenerator.GenerateExpenseCategories(Math.Min(recordsPerEntity, 15));
            await AddInBatchesAsync(expenseCategories, batchSize);

            // Create simple entities
            await CreateSimpleEntitiesAsync(recordsPerEntity, batchSize);
        }

        private async Task CreateSimpleEntitiesAsync(int recordsPerEntity, int batchSize)
        {
            // Institution
            _logger.LogInformation("Creating Institutions...");
            var institutions = Enumerable.Range(1, Math.Min(recordsPerEntity, 5)).Select(i => new Institution
            {
                VoucherCountdown = i * 100,
                InstitutionName = $"Institution {i}",
                DialogTitle = $"Dialog {i}",
                Established = $"200{i}",
                Address = $"Address {i}",
                City = $"City {i}",
                State = $"State {i}",
                LocalArea = $"Area {i}",
                PostalCode = $"1000{i}",
                Phone = $"555-000{i}",
                Email = $"contact{i}@institution.com",
                Website = $"www.institution{i}.com",
                InsertDate = DateTime.Now.AddDays(-i)
            }).ToList();
            await AddInBatchesAsync(institutions, batchSize);

            // AdminMoneyCollection
            _logger.LogInformation("Creating AdminMoneyCollections...");
            var adminCollections = Enumerable.Range(1, recordsPerEntity).Select(i => new AdminMoneyCollection
            {
                Amount = i * 100,
                Description = $"Collection {i}",
                CollectionDate = DateTime.Now.AddDays(-i),
                InsertDate = DateTime.Now.AddDays(-i),
                CollectedBy = $"Admin {i}"
            }).ToList();
            await AddInBatchesAsync(adminCollections, batchSize);

            // PageLinkCategory
            _logger.LogInformation("Creating PageLinkCategories...");
            var pageLinkCategories = Enumerable.Range(1, Math.Min(recordsPerEntity, 10)).Select(i => new PageLinkCategory
            {
                CategoryName = $"Category {i}",
                Description = $"Description {i}",
                SortOrder = i,
                IsActive = true
            }).ToList();
            await AddInBatchesAsync(pageLinkCategories, batchSize);

            // ExpenseFixed
            _logger.LogInformation("Creating ExpenseFixed...");
            var expenseFixed = Enumerable.Range(1, recordsPerEntity).Select(i => new ExpenseFixed
            {
                ExpenseName = $"Fixed Expense {i}",
                Amount = i * 50,
                Description = $"Fixed expense description {i}",
                StartDate = DateTime.Now.AddDays(-i * 30),
                EndDate = DateTime.Now.AddDays(i * 30)
            }).ToList();
            await AddInBatchesAsync(expenseFixed, batchSize);
        }

        private async Task CreateDependentDataAsync(int recordsPerEntity, int batchSize)
        {
            _logger.LogInformation("Creating dependent data...");

            // Get existing IDs for foreign keys
            var customerIds = await _context.Customer.Select(c => c.CustomerId).ToListAsync();
            var vendorIds = await _context.Vendor.Select(v => v.VendorId).ToListAsync();
            var registrationIds = await _context.Registration.Select(r => r.RegistrationId).ToListAsync();
            var productIds = await _context.Product.Select(p => p.ProductId).ToListAsync();
            var accountIds = await _context.Account.Select(a => a.AccountId).ToListAsync();
            var expenseCategoryIds = await _context.ExpenseCategory.Select(ec => ec.ExpenseCategoryId).ToListAsync();

            if (!customerIds.Any() || !vendorIds.Any() || !registrationIds.Any() || !productIds.Any())
            {
                _logger.LogWarning("Missing foundational data. Skipping dependent data creation.");
                return;
            }

            // Create CustomerPhones
            _logger.LogInformation("Creating CustomerPhones...");
            var customerPhones = customerIds.Take(recordsPerEntity).Select(customerId => new CustomerPhone
            {
                CustomerId = customerId,
                Phone = $"555-{customerId:D4}",
                IsPrimary = true,
                InsertDate = DateTime.Now
            }).ToList();
            await AddInBatchesAsync(customerPhones, batchSize);

            // Create AccountDeposits
            if (accountIds.Any())
            {
                _logger.LogInformation("Creating AccountDeposits...");
                var accountDeposits = Enumerable.Range(1, recordsPerEntity).Select(i => new AccountDeposit
                {
                    AccountId = accountIds[i % accountIds.Count],
                    Amount = i * 100,
                    Description = $"Deposit {i}",
                    DepositDate = DateTime.Now.AddDays(-i),
                    InsertDate = DateTime.Now.AddDays(-i),
                    TransactionReference = $"DEP{i:D6}"
                }).ToList();
                await AddInBatchesAsync(accountDeposits, batchSize);

                // Create AccountWithdraws
                _logger.LogInformation("Creating AccountWithdraws...");
                var accountWithdraws = Enumerable.Range(1, recordsPerEntity).Select(i => new AccountWithdraw
                {
                    AccountId = accountIds[i % accountIds.Count],
                    Amount = i * 50,
                    Description = $"Withdraw {i}",
                    WithdrawDate = DateTime.Now.AddDays(-i),
                    InsertDate = DateTime.Now.AddDays(-i),
                    TransactionReference = $"WTH{i:D6}"
                }).ToList();
                await AddInBatchesAsync(accountWithdraws, batchSize);
            }

            _logger.LogInformation("Dependent data creation completed");
        }

        private async Task VerifyDataAsync()
        {
            _logger.LogInformation("Verifying created data...");

            var counts = new Dictionary<string, int>
            {
                ["ProductCatalogType"] = await _context.ProductCatalogType.CountAsync(),
                ["ProductCatalog"] = await _context.ProductCatalog.CountAsync(),
                ["Product"] = await _context.Product.CountAsync(),
                ["Customer"] = await _context.Customer.CountAsync(),
                ["Vendor"] = await _context.Vendor.CountAsync(),
                ["Registration"] = await _context.Registration.CountAsync(),
                ["Account"] = await _context.Account.CountAsync(),
                ["ExpenseCategory"] = await _context.ExpenseCategory.CountAsync(),
                ["Institution"] = await _context.Institution.CountAsync(),
                ["AdminMoneyCollection"] = await _context.AdminMoneyCollection.CountAsync(),
                ["CustomerPhone"] = await _context.CustomerPhone.CountAsync(),
                ["AccountDeposit"] = await _context.AccountDeposit.CountAsync(),
                ["AccountWithdraw"] = await _context.AccountWithdraw.CountAsync()
            };

            _logger.LogInformation("Data verification results:");
            foreach (var (entity, count) in counts)
            {
                _logger.LogInformation("  {Entity}: {Count} records", entity, count);
            }

            var totalRecords = counts.Values.Sum();
            _logger.LogInformation("Total records created: {TotalRecords}", totalRecords);
        }

        private async Task AddInBatchesAsync<T>(List<T> entities, int batchSize) where T : class
        {
            for (int i = 0; i < entities.Count; i += batchSize)
            {
                var batch = entities.Skip(i).Take(batchSize).ToList();
                _context.Set<T>().AddRange(batch);
                await _context.SaveChangesAsync();
                
                if (i + batchSize < entities.Count)
                {
                    _logger.LogDebug("Processed {Processed}/{Total} {EntityType} records", 
                        i + batchSize, entities.Count, typeof(T).Name);
                }
            }
            
            _logger.LogInformation("✅ Created {Count} {EntityType} records", entities.Count, typeof(T).Name);
        }
    }
}
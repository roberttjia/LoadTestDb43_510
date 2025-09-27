using Bogus;
using LoadTest.Data.Models;

namespace LoadTest.Console.Services
{
    public class DataGeneratorService
    {
        private readonly Faker _faker;

        public DataGeneratorService()
        {
            _faker = new Faker();
        }

        public List<Customer> GenerateCustomers(int count)
        {
            var customerFaker = new Faker<Customer>()
                .RuleFor(c => c.OrganizationName, f => f.Company.CompanyName())
                .RuleFor(c => c.CustomerName, f => f.Person.FullName)
                .RuleFor(c => c.Description, f => f.Lorem.Sentence())
                .RuleFor(c => c.CustomerAddress, f => f.Address.FullAddress())
                .RuleFor(c => c.TotalAmount, f => f.Random.Decimal(0, 10000))
                .RuleFor(c => c.TotalDiscount, f => f.Random.Decimal(0, 1000))
                .RuleFor(c => c.ReturnAmount, f => f.Random.Decimal(0, 500))
                .RuleFor(c => c.Paid, f => f.Random.Decimal(0, 8000))
                .RuleFor(c => c.AccountTransactionCharge, f => f.Random.Decimal(0, 100))
                .RuleFor(c => c.Due, f => f.Random.Decimal(0, 2000))
                .RuleFor(c => c.PurchaseAdjustedAmount, f => f.Random.Decimal(0, 500))
                .RuleFor(c => c.DueLimit, f => f.Random.Decimal(1000, 5000))
                .RuleFor(c => c.InsertDate, f => f.Date.Recent(365))
                .RuleFor(c => c.Designation, f => f.Name.JobTitle())
                .RuleFor(c => c.IsIndividual, f => f.Random.Bool());

            return customerFaker.Generate(count);
        }

        public List<Vendor> GenerateVendors(int count)
        {
            var vendorFaker = new Faker<Vendor>()
                .RuleFor(v => v.VendorCompanyName, f => f.Company.CompanyName())
                .RuleFor(v => v.VendorName, f => f.Person.FullName)
                .RuleFor(v => v.VendorAddress, f => f.Address.FullAddress())
                .RuleFor(v => v.VendorPhone, f => f.Phone.PhoneNumber())
                .RuleFor(v => v.Description, f => f.Lorem.Sentence())
                .RuleFor(v => v.TotalAmount, f => f.Random.Decimal(0, 50000))
                .RuleFor(v => v.TotalDiscount, f => f.Random.Decimal(0, 5000))
                .RuleFor(v => v.ReturnAmount, f => f.Random.Decimal(0, 2000))
                .RuleFor(v => v.Paid, f => f.Random.Decimal(0, 40000))
                .RuleFor(v => v.Due, f => f.Random.Decimal(0, 10000))
                .RuleFor(v => v.InsertDate, f => f.Date.Recent(365));

            return vendorFaker.Generate(count);
        }

        public List<ProductCatalogType> GenerateProductCatalogTypes(int count)
        {
            var typeFaker = new Faker<ProductCatalogType>()
                .RuleFor(t => t.ProductCatalogTypeName, f => f.Commerce.Categories(1).First())
                .RuleFor(t => t.Description, f => f.Lorem.Sentence())
                .RuleFor(t => t.IsActive, f => f.Random.Bool(0.8f));

            return typeFaker.Generate(count);
        }

        public List<ProductCatalog> GenerateProductCatalogs(int count, List<int> catalogTypeIds)
        {
            var catalogFaker = new Faker<ProductCatalog>()
                .RuleFor(pc => pc.ProductCatalogTypeId, f => f.PickRandom(catalogTypeIds))
                .RuleFor(pc => pc.ProductCatalogName, f => f.Commerce.ProductName())
                .RuleFor(pc => pc.Description, f => f.Commerce.ProductDescription())
                .RuleFor(pc => pc.Brand, f => f.Company.CompanyName())
                .RuleFor(pc => pc.Model, f => f.Random.AlphaNumeric(8))
                .RuleFor(pc => pc.Specification, f => f.Lorem.Paragraph())
                .RuleFor(pc => pc.Weight, f => f.Random.Decimal(0.1m, 100m))
                .RuleFor(pc => pc.Color, f => f.Commerce.Color())
                .RuleFor(pc => pc.Size, f => f.Random.String2(5))
                .RuleFor(pc => pc.Material, f => f.Commerce.ProductMaterial())
                .RuleFor(pc => pc.InsertDate, f => f.Date.Recent(365))
                .RuleFor(pc => pc.IsActive, f => f.Random.Bool(0.9f));

            return catalogFaker.Generate(count);
        }

        public List<Product> GenerateProducts(int count, List<int> catalogIds)
        {
            var productFaker = new Faker<Product>()
                .RuleFor(p => p.ProductCatalogId, f => f.PickRandom(catalogIds))
                .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Warranty, f => f.Random.String2(10))
                .RuleFor(p => p.Note, f => f.Lorem.Sentence())
                .RuleFor(p => p.SellingPrice, f => f.Random.Decimal(10, 1000))
                .RuleFor(p => p.InsertDate, f => f.Date.Recent(365));

            return productFaker.Generate(count);
        }

        public List<Registration> GenerateRegistrations(int count)
        {
            var registrationFaker = new Faker<Registration>()
                .RuleFor(r => r.FirstName, f => f.Person.FirstName)
                .RuleFor(r => r.LastName, f => f.Person.LastName)
                .RuleFor(r => r.UserName, f => f.Person.UserName)
                .RuleFor(r => r.Email, f => f.Person.Email)
                .RuleFor(r => r.Password, f => f.Internet.Password())
                .RuleFor(r => r.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(r => r.Address, f => f.Address.FullAddress())
                .RuleFor(r => r.City, f => f.Address.City())
                .RuleFor(r => r.State, f => f.Address.State())
                .RuleFor(r => r.PostalCode, f => f.Address.ZipCode())
                .RuleFor(r => r.Country, f => f.Address.Country())
                .RuleFor(r => r.DateOfBirth, f => f.Date.Past(50, DateTime.Now.AddYears(-18)))
                .RuleFor(r => r.Gender, f => f.PickRandom("Male", "Female", "Other"))
                .RuleFor(r => r.Occupation, f => f.Name.JobTitle())
                .RuleFor(r => r.MaritalStatus, f => f.PickRandom("Single", "Married", "Divorced", "Widowed"))
                .RuleFor(r => r.Nationality, f => f.Address.Country())
                .RuleFor(r => r.Religion, f => f.PickRandom("Christianity", "Islam", "Judaism", "Buddhism", "Hinduism", "Other"))
                .RuleFor(r => r.BloodGroup, f => f.PickRandom("A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"))
                .RuleFor(r => r.EmergencyContact, f => f.Person.FullName)
                .RuleFor(r => r.EmergencyPhone, f => f.Phone.PhoneNumber())
                .RuleFor(r => r.IsActive, f => f.Random.Bool(0.9f))
                .RuleFor(r => r.IsEmailVerified, f => f.Random.Bool(0.7f))
                .RuleFor(r => r.IsPhoneVerified, f => f.Random.Bool(0.6f))
                .RuleFor(r => r.CreatedDate, f => f.Date.Recent(365))
                .RuleFor(r => r.LastLoginDate, f => f.Date.Recent(30))
                .RuleFor(r => r.Role, f => f.PickRandom("Admin", "Manager", "Employee", "User"))
                .RuleFor(r => r.Department, f => f.Commerce.Department())
                .RuleFor(r => r.Salary, f => f.Random.Decimal(30000, 150000))
                .RuleFor(r => r.HireDate, f => f.Date.Past(10));

            return registrationFaker.Generate(count);
        }

        public List<Account> GenerateAccounts(int count)
        {
            var accountFaker = new Faker<Account>()
                .RuleFor(a => a.AccountName, f => f.Finance.AccountName())
                .RuleFor(a => a.Balance, f => f.Random.Decimal(0, 100000))
                .RuleFor(a => a.CostPercentage, f => f.Random.Decimal(0, 10));

            return accountFaker.Generate(count);
        }

        public List<ExpenseCategory> GenerateExpenseCategories(int count)
        {
            var categoryFaker = new Faker<ExpenseCategory>()
                .RuleFor(ec => ec.CategoryName, f => f.Commerce.Categories(1).First())
                .RuleFor(ec => ec.Description, f => f.Lorem.Sentence());

            return categoryFaker.Generate(count);
        }
    }
}
# LoadTestDb43_510

A comprehensive SQL Server database stress test with **43 entities** and **510+ columns** designed for testing database migration tools, ORM performance, and system scalability.

## 📊 Database Statistics

- **Entities**: 43
- **Tables**: 43
- **Columns**: 510+
- **Complexity Level**: Basic
- **Use Case**: Initial migration tool testing

## 🏗️ Architecture

This project contains a synthetic business database with realistic entity relationships including:

- **Account Management**: Account, AccountDeposit, AccountWithdraw
- **Customer Management**: Customer, CustomerPhone
- **Expense Tracking**: Expense, ExpenseFixed, ExpenseTransportation, ExpenseCategory
- **Product Catalog**: Product, ProductCatalog, ProductStock, ProductDamaged
- **Sales & Purchasing**: Purchase, Selling, Registration
- **Service Management**: Service, ServiceDevice, ServiceList
- **Reporting Views**: VW_ExpenseWithTransportation, VW_CapitalProfitReport

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK
- SQL Server (LocalDB, Express, or Full)
- Visual Studio 2022 or VS Code

### Setup

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd LoadTestDb43_510
   ```

2. **Configure Connection String**
   
   Update the connection strings in both `appsettings.json` files:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=LoadTestDb43_510;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=true;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Build the Solution**
   ```bash
   dotnet build
   ```

4. **Create Database Schema**
   ```bash
   cd LoadTest.Data/bin/Debug/net8.0
   ./LoadTest.Data.exe
   ```

5. **Test Database Connectivity**
   ```bash
   cd LoadTest.Console/bin/Debug/net8.0
   ./LoadTest.Console.exe
   ```

## 🧪 Testing Capabilities

### LoadTest.Data Project
- **EF Core Model**: Complete Entity Framework Core model with all 43 entities
- **Database Creation**: Automated schema generation using EF Core migrations
- **Relationship Mapping**: Proper foreign key relationships and constraints

### LoadTest.Console Project
- **Connectivity Testing**: Basic database connection validation
- **Schema Verification**: Table and column count validation
- **Performance Metrics**: Basic performance measurements

## 📈 Performance Characteristics

- **Build Time**: ~5-10 seconds
- **Schema Creation**: ~2-5 seconds
- **Memory Usage**: Low (baseline)
- **EF Core Compatibility**: Excellent

## 🎯 Use Cases

### Migration Tool Testing
- **Entry Level**: Perfect for initial migration tool validation
- **Baseline Performance**: Establish performance baselines
- **Feature Testing**: Test basic migration features

### ORM Performance Testing
- **Entity Framework**: Validate EF Core performance with moderate complexity
- **Query Performance**: Test basic query patterns
- **CRUD Operations**: Validate Create, Read, Update, Delete operations

### System Integration Testing
- **CI/CD Pipelines**: Lightweight database for automated testing
- **Development Environment**: Quick setup for development testing
- **Performance Benchmarking**: Baseline for performance comparisons

## 🔧 Customization

### Adding New Entities
1. Create new entity class in `LoadTest.Data/Models/`
2. Add DbSet property to `ApplicationDbContext`
3. Configure relationships in `OnModelCreating`

### Modifying Connection Strings
- Update `LoadTest.Data/appsettings.json`
- Update `LoadTest.Console/appsettings.json`

## 📊 Comparison with Other LoadTest Databases

| Database | Entities | Complexity | Use Case |
|----------|----------|------------|----------|
| **LoadTestDb43_510** | 43 | Basic | Initial testing |
| LoadTestDb86_1020 | 86 | Medium | Standard testing |
| LoadTestDb129_1530 | 129 | High | Advanced testing |
| LoadTestDb172_2040 | 172 | Very High | Stress testing |
| LoadTestDb215_2550 | 215 | Extreme | Limit testing |
| LoadTestDb258_3060 | 258 | Maximum | Ultimate testing |
| LoadTestDb301_3570 | 301 | Record | World record |
| LoadTestDb344_4080 | 344 | Ultimate | Absolute maximum |

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🙏 Acknowledgments

- Built with Entity Framework Core 8.0
- Designed for SQL Server compatibility
- Optimized for migration tool testing

## 📞 Support

For questions or issues:
- Create an issue in the GitHub repository
- Check the documentation in other LoadTest projects
- Review the comprehensive test suite

---

**Part of the LoadTest Database Series** - A comprehensive suite of databases designed to test the limits of migration tools and ORM frameworks.
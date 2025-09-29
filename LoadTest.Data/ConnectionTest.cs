using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LoadTest.Data
{
    public class ConnectionTest
    {
        public static async Task<int> Main(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            // Setup logging
            using var loggerFactory = LoggerFactory.Create(builder =>
                builder.AddConsole().SetMinimumLevel(LogLevel.Information));
            var logger = loggerFactory.CreateLogger<ConnectionTest>();

            // Test different connection strings
            var testConnections = new Dictionary<string, string>
            {
                ["Current Config"] = configuration.GetConnectionString("DefaultConnection") ?? "",
                ["IP Address"] = "Server=18.211.185.224;Database=LoadTestDb43_510;User Id=dbmod;Password=Password12345!;TrustServerCertificate=true;MultipleActiveResultSets=true",
                ["IP with Port"] = "Server=18.211.185.224,1433;Database=LoadTestDb43_510;User Id=dbmod;Password=Password12345!;TrustServerCertificate=true;MultipleActiveResultSets=true",
                ["localhost"] = "Server=localhost;Database=LoadTestDb43_510;User Id=dbmod;Password=Password12345!;TrustServerCertificate=true;MultipleActiveResultSets=true",
                ["127.0.0.1"] = "Server=127.0.0.1;Database=LoadTestDb43_510;User Id=dbmod;Password=Password12345!;TrustServerCertificate=true;MultipleActiveResultSets=true"
            };

            logger.LogInformation("Testing SQL Server connections...");
            
            foreach (var (name, connectionString) in testConnections)
            {
                logger.LogInformation("Testing {Name}: {ConnectionString}", name, MaskPassword(connectionString));
                
                try
                {
                    using var connection = new SqlConnection(connectionString);
                    await connection.OpenAsync();
                    
                    var command = new SqlCommand("SELECT @@VERSION", connection);
                    var version = await command.ExecuteScalarAsync();
                    
                    logger.LogInformation("✅ SUCCESS - {Name}: {Version}", name, version?.ToString()?.Split('\n')[0]);
                    
                    // Test if database exists
                    var dbCommand = new SqlCommand("SELECT COUNT(*) FROM sys.databases WHERE name = 'LoadTestDb43_510'", connection);
                    var dbExists = (int)(await dbCommand.ExecuteScalarAsync() ?? 0) > 0;
                    
                    logger.LogInformation("   Database LoadTestDb43_510 exists: {Exists}", dbExists);
                    
                    return 0; // Success - use this connection
                }
                catch (Exception ex)
                {
                    logger.LogWarning("❌ FAILED - {Name}: {Error}", name, ex.Message);
                }
            }

            logger.LogError("No working SQL Server connection found. Please check:");
            logger.LogError("1. SQL Server is installed and running");
            logger.LogError("2. SQL Server Authentication is enabled");
            logger.LogError("3. User 'dbmod' exists with correct password");
            logger.LogError("4. Firewall allows SQL Server connections");
            
            return 1;
        }

        private static string MaskPassword(string connectionString)
        {
            return connectionString.Replace("Password=Password12345!", "Password=***");
        }
    }
}
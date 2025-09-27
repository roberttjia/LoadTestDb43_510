using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LoadTest.Console
{
    public class SimpleTest
    {
        public static async Task<int> Main(string[] args)
        {
            System.Console.WriteLine("Starting simple connection test...");
            
            try
            {
                // Build configuration
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false)
                    .AddEnvironmentVariables()
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                System.Console.WriteLine($"Connection string: {MaskPassword(connectionString)}");

                // Test basic connection
                System.Console.WriteLine("Testing SQL connection...");
                using var connection = new SqlConnection(connectionString);
                
                System.Console.WriteLine("Opening connection...");
                await connection.OpenAsync();
                System.Console.WriteLine("✅ Connection opened successfully!");

                // Test simple query
                System.Console.WriteLine("Testing simple query...");
                var command = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES", connection);
                var tableCount = await command.ExecuteScalarAsync();
                System.Console.WriteLine($"✅ Found {tableCount} tables in database");

                // Test specific table
                System.Console.WriteLine("Testing Customer table...");
                var customerCommand = new SqlCommand("SELECT COUNT(*) FROM Customer", connection);
                var customerCount = await customerCommand.ExecuteScalarAsync();
                System.Console.WriteLine($"✅ Found {customerCount} customers");

                System.Console.WriteLine("✅ All tests passed!");
                return 0;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"❌ Error: {ex.Message}");
                System.Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return 1;
            }
        }

        private static string MaskPassword(string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                return "null";
            
            return connectionString.Replace("Password=Password12345!", "Password=***");
        }
    }
}
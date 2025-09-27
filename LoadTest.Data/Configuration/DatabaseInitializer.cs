using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LoadTest.Data.Configuration
{
    public static class DatabaseInitializer
    {
        public static async Task InitializeDatabaseAsync(IConfiguration configuration, string connectionStringName = "DefaultConnection", ILogger? logger = null)
        {
            var connectionString = configuration.GetConnectionString(connectionStringName);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"Connection string '{connectionStringName}' not found.");
            }

            logger?.LogInformation("Initializing database with connection: {ConnectionStringName}", connectionStringName);

            using var context = DatabaseConfiguration.CreateDbContext(connectionString);
            
            try
            {
                // Create database if it doesn't exist
                logger?.LogInformation("Creating database if it doesn't exist...");
                await context.Database.EnsureCreatedAsync();
                
                logger?.LogInformation("Database initialization completed successfully.");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Error initializing database");
                throw;
            }
        }

        public static async Task<bool> CanConnectAsync(IConfiguration configuration, string connectionStringName = "DefaultConnection", ILogger? logger = null)
        {
            var connectionString = configuration.GetConnectionString(connectionStringName);
            if (string.IsNullOrEmpty(connectionString))
            {
                return false;
            }

            try
            {
                using var context = DatabaseConfiguration.CreateDbContext(connectionString);
                await context.Database.CanConnectAsync();
                logger?.LogInformation("Successfully connected to database using {ConnectionStringName}", connectionStringName);
                return true;
            }
            catch (Exception ex)
            {
                logger?.LogWarning(ex, "Failed to connect to database using {ConnectionStringName}", connectionStringName);
                return false;
            }
        }

        public static async Task DeleteDatabaseAsync(IConfiguration configuration, string connectionStringName = "DefaultConnection", ILogger? logger = null)
        {
            var connectionString = configuration.GetConnectionString(connectionStringName);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"Connection string '{connectionStringName}' not found.");
            }

            logger?.LogWarning("Deleting database with connection: {ConnectionStringName}", connectionStringName);

            using var context = DatabaseConfiguration.CreateDbContext(connectionString);
            
            try
            {
                await context.Database.EnsureDeletedAsync();
                logger?.LogInformation("Database deleted successfully.");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Error deleting database");
                throw;
            }
        }
    }
}
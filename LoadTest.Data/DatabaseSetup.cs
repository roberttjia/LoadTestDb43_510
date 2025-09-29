using LoadTest.Data.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LoadTest.Data
{
    public class DatabaseSetup
    {
        public static async Task<int> Main(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            // Setup logging
            using var loggerFactory = LoggerFactory.Create(builder =>
                builder.AddConsole().SetMinimumLevel(LogLevel.Information));
            var logger = loggerFactory.CreateLogger<DatabaseSetup>();

            try
            {
                var connectionStringName = args.Length > 0 ? args[0] : "DefaultConnection";
                
                logger.LogInformation("Starting database setup using connection: {ConnectionString}", connectionStringName);

                // First, try to create the login and database using master connection
                logger.LogInformation("Creating login and database...");
                await CreateLoginAndDatabaseAsync(configuration, connectionStringName, logger);

                // Test connection to the specific database
                logger.LogInformation("Testing database connection...");
                var canConnect = await DatabaseInitializer.CanConnectAsync(configuration, connectionStringName, logger);
                
                if (!canConnect)
                {
                    logger.LogError("Cannot connect to database. Please check your connection string and ensure SQL Server is running.");
                    return 1;
                }

                // Initialize database with EF Core
                logger.LogInformation("Initializing database with EF Core...");
                await DatabaseInitializer.InitializeDatabaseAsync(configuration, connectionStringName, logger);

                logger.LogInformation("Database setup completed successfully!");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Database setup failed");
                return 1;
            }
        }

        private static async Task CreateLoginAndDatabaseAsync(IConfiguration configuration, string connectionStringName, ILogger logger)
        {
            var connectionString = configuration.GetConnectionString(connectionStringName);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"Connection string '{connectionStringName}' not found.");
            }

            // Parse connection string to get server and database info
            var builder = new SqlConnectionStringBuilder(connectionString);
            var server = builder.DataSource;
            var database = builder.InitialCatalog;
            var userId = builder.UserID;
            var password = builder.Password;

            // Create master connection string (to create login and database)
            var masterConnectionString = new SqlConnectionStringBuilder(connectionString)
            {
                InitialCatalog = "master"
            }.ToString();

            logger.LogInformation("Connecting to master database to create login and database...");

            try
            {
                using var connection = new SqlConnection(masterConnectionString);
                await connection.OpenAsync();

                // Create login if it doesn't exist
                logger.LogInformation("Creating login '{UserId}' if it doesn't exist...", userId);
                var createLoginSql = $@"
                    IF NOT EXISTS (SELECT name FROM sys.sql_logins WHERE name = '{userId}')
                    BEGIN
                        CREATE LOGIN [{userId}] WITH PASSWORD = '{password}';
                        PRINT 'Login {userId} created successfully.';
                    END
                    ELSE
                    BEGIN
                        PRINT 'Login {userId} already exists.';
                    END";

                using var loginCommand = new SqlCommand(createLoginSql, connection);
                await loginCommand.ExecuteNonQueryAsync();

                // Create database if it doesn't exist
                logger.LogInformation("Creating database '{Database}' if it doesn't exist...", database);
                var createDbSql = $@"
                    IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '{database}')
                    BEGIN
                        CREATE DATABASE [{database}];
                        PRINT 'Database {database} created successfully.';
                    END
                    ELSE
                    BEGIN
                        PRINT 'Database {database} already exists.';
                    END";

                using var dbCommand = new SqlCommand(createDbSql, connection);
                await dbCommand.ExecuteNonQueryAsync();

                // Create user in the database
                logger.LogInformation("Creating user '{UserId}' in database '{Database}'...", userId, database);
                var createUserSql = $@"
                    USE [{database}];
                    IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = '{userId}')
                    BEGIN
                        CREATE USER [{userId}] FOR LOGIN [{userId}];
                        ALTER ROLE db_owner ADD MEMBER [{userId}];
                        PRINT 'User {userId} created and added to db_owner role.';
                    END
                    ELSE
                    BEGIN
                        PRINT 'User {userId} already exists in database.';
                    END";

                using var userCommand = new SqlCommand(createUserSql, connection);
                await userCommand.ExecuteNonQueryAsync();

                logger.LogInformation("✅ Login, database, and user setup completed successfully!");
            }
            catch (Exception ex)
            {
                logger.LogWarning("Could not create login/database using current credentials: {Error}", ex.Message);
                logger.LogInformation("This is normal if the dbmod user doesn't have admin rights. Proceeding with existing setup...");
            }
        }
    }
}
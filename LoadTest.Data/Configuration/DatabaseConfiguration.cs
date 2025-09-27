using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoadTest.Data.Configuration
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddLoadTestDatabase(this IServiceCollection services, IConfiguration configuration, string connectionStringName = "DefaultConnection")
        {
            var connectionString = configuration.GetConnectionString(connectionStringName);
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                }));

            return services;
        }

        public static DbContextOptionsBuilder<ApplicationDbContext> ConfigureSqlServer(this DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder, string connectionString)
        {
            return optionsBuilder.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });
        }

        public static ApplicationDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.ConfigureSqlServer(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
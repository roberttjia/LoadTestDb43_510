using LoadTest.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LoadTest.Console.Services
{
    public class LoadTestService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataGeneratorService _dataGenerator;
        private readonly EntityTestService _entityTest;
        private readonly IConfiguration _configuration;
        private readonly ILogger<LoadTestService> _logger;

        public LoadTestService(
            ApplicationDbContext context,
            DataGeneratorService dataGenerator,
            EntityTestService entityTest,
            IConfiguration configuration,
            ILogger<LoadTestService> logger)
        {
            _context = context;
            _dataGenerator = dataGenerator;
            _entityTest = entityTest;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task RunLoadTestAsync()
        {
            var recordsPerEntity = _configuration.GetValue<int>("LoadTest:RecordsPerEntity", 100);
            var batchSize = _configuration.GetValue<int>("LoadTest:BatchSize", 50);

            _logger.LogInformation("Starting load test with {RecordsPerEntity} records per entity, batch size {BatchSize}", 
                recordsPerEntity, batchSize);

            try
            {
                // Test database connection
                _logger.LogInformation("Testing database connection...");
                await _context.Database.CanConnectAsync();
                _logger.LogInformation("✅ Database connection successful");

                // Run entity tests
                await _entityTest.TestAllEntitiesAsync(recordsPerEntity, batchSize);

                _logger.LogInformation("✅ Load test completed successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Load test failed");
                throw;
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Fixtures
{
    public abstract class EfDatabaseBaseFixture<TDbContext> : IDisposable where TDbContext : DbContext
    {
        private readonly string _connectionString;
        private readonly DbContextOptions<TDbContext> _options;

        public EfDatabaseBaseFixture(string connectionString)
        {
            _connectionString = connectionString;

            // Configure DbContextOptions with PostgreSQL provider
            _options = new DbContextOptionsBuilder<TDbContext>()
                .UseNpgsql(connectionString)
                .EnableSensitiveDataLogging()
                .Options;
        }

        public TDbContext BuildDbContext(string dbName)
        {
            try
            {
                var db = BuildDbContext(_options);
                db.Database.EnsureCreated();
                return db;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to connect to database.", ex);
            }
        }

        protected abstract TDbContext BuildDbContext(DbContextOptions<TDbContext> options);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

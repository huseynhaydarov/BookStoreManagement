using Infrastructure.Persistence.DataBases;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Fixtures;

public class DbContextFixture : EfDatabaseBaseFixture<EFContext>
{
    private const string ConnectionString = "Host=localhost;Port=5433;Database=BSM;Username=postgres;Password=7878_Postgresql";

    public DbContextFixture()
        : base(ConnectionString)
    {
    }

    protected override EFContext BuildDbContext(DbContextOptions<EFContext> options)
    {
        return new EFContext(options);
    }
}

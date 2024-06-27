using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence.DataBases;

public class EFContextFactory : IDesignTimeDbContextFactory<EFContext>
{
    public EFContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EFContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=BSM;Username=postgres;Password=7878_Postgresql");

        return new EFContext(optionsBuilder.Options);
    }
}
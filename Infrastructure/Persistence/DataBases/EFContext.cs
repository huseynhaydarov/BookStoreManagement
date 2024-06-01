using Domain.Abstract;
using Infrastructure.Persistence.TablesConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.DataBases;

public class EFContext : DbContext
{
    public EFContext(DbContextOptions<EFContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=BSM;Username=postgres;Password=7878_Postgresql");
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<BaseEntity>();
        modelBuilder.Ignore<Person>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
    }
}


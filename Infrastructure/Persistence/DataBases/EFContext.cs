using Domain.Abstract;
using Domain.Entities;
using Infrastructure.Persistence.TablesConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.DataBases;

public class EFContext : DbContext
{   
    public DbSet<AuthorEntity> Authors { get; set; }
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
        modelBuilder.Entity<AuthorEntity>().ToTable("AuthorEntity"); 
        base.OnModelCreating(modelBuilder);

        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<BaseEntity>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
        modelBuilder.Entity<IdentityUser>().ToTable("Users");
        modelBuilder.Entity<IdentityRole>().ToTable("Roles").HasNoKey();
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles").HasNoKey();
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims").HasNoKey();
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins").HasNoKey();
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens").HasNoKey();
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims").HasNoKey();
    }
}


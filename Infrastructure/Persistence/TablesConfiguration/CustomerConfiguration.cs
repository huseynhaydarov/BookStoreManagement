using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.TablesConfiguration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.RegisteredDate).IsRequired();
        builder.Property(c => c.Email).IsRequired();
        builder.HasMany(c => c.Accounts).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId);
        builder.HasMany(c => c.Orders).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId);
    }
}

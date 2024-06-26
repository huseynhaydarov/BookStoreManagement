﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.TablesConfiguration;

public class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.RegisteredDate).IsRequired();
        builder.Property(c => c.Email).IsRequired();
        builder.HasMany(c => c.Accounts).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId);
        builder.HasMany(c => c.Orders).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId);
    }
}
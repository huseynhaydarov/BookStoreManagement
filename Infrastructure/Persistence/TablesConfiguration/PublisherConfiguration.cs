﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.TablesConfiguration;

public class PublisherConfiguration : IEntityTypeConfiguration<PublisherEntity>
{
    public void Configure(EntityTypeBuilder<PublisherEntity> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
        builder.Property(p => p.Address).HasMaxLength(150).IsRequired();
        builder.Property(p => p.Phone).HasMaxLength(150).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(150).IsRequired();
        builder.HasMany(p => p.Books).WithOne(p => p.Publisher).HasForeignKey(p => p.PublisherId);
    }
}
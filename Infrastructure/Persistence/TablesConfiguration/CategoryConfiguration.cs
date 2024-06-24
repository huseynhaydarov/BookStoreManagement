using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.TablesConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.HasKey(ca => ca.Id);
        builder.Property(ca => ca.Name).HasMaxLength(150).IsRequired();
        builder.Property(ca => ca.Description).HasMaxLength(300).IsRequired();
        builder.HasMany(ca => ca.Books).WithOne(ca => ca.Category).HasForeignKey(ca => ca.CategoryId);
    }
}

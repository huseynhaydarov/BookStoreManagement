using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.TablesConfiguration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(a  => a.Id);
        builder.Property(a => a.DateOfBirth).IsRequired();
        builder.Property(a => a.FullName).HasMaxLength(150).IsRequired();
        builder.Property(a => a.Biography).HasMaxLength(500).IsRequired();
        builder.HasMany(a => a.Books).WithOne(a => a.Author).HasForeignKey(a => a.AuthorId);
    }
}

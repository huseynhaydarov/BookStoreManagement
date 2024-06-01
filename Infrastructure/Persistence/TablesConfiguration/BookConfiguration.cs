using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.TablesConfiguration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(bk => bk.Id);
        builder.Property(bk => bk.Title).HasMaxLength(150).IsRequired();
        builder.Property(bk => bk.Description).HasMaxLength(300).IsRequired();
        builder.Property(bk => bk.Price).HasPrecision(18, 2).IsRequired();
        builder.Property(bk => bk.PageSize).IsRequired();
        builder.Property(bk => bk.PublicationYear).IsRequired();
        builder.Property(bk => bk.StockQuantity).IsRequired();
        builder.Property(bk => bk.ISBN).HasMaxLength(150).IsRequired();
        builder.Property(bk => bk.Type).HasConversion(
            bk => bk.ToString(),
            bk => (BookType)Enum.Parse(typeof(BookType), bk));
        builder.HasMany(bk => bk.Items).WithOne(bk => bk.Book).HasForeignKey(bk => bk.BookId);
    }
}

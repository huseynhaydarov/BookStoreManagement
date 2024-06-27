using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.TablesConfiguration;

public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(bk => bk.Id);
        builder.Property(bk => bk.Title).HasMaxLength(150).IsRequired();
        builder.Property(bk => bk.Description).HasMaxLength(300).IsRequired();
        builder.Property(bk => bk.Price).HasPrecision(18, 2).IsRequired();
        builder.Property(bk => bk.PageSize).IsRequired();
        builder.Property(bk => bk.PublicationYear).IsRequired();
        builder.Property(bk => bk.StockQuantity).IsRequired();
        builder.Property(bk => bk.ISBN).HasMaxLength(150).IsRequired();
        builder.Property(bk => bk.ImagePath).HasMaxLength(150).IsRequired();
        builder.Property(bk => bk.Type).HasConversion(
            bk => bk.ToString(),
            bk => (BookType)Enum.Parse(typeof(BookType), bk));
        builder.HasMany(bk => bk.Items).WithOne(bk => bk.Book).HasForeignKey(bk => bk.BookId);
    }
}
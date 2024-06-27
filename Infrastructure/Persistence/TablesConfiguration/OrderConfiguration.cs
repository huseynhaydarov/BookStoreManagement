using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.TablesConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<OrderEnitity>
{
    public void Configure(EntityTypeBuilder<OrderEnitity> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.OrderDate).IsRequired();
        builder.Property(o => o.Status).HasConversion(
            o => o.ToString(),
            o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o));
        builder.Property(o => o.TotalAmount).HasPrecision(18, 2).IsRequired();
        builder.HasMany(o => o.Items).WithOne(o => o.Order).HasForeignKey(o => o.OrderId);
    }
}
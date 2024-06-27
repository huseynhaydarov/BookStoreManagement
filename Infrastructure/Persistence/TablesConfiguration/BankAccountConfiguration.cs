using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.TablesConfiguration;

public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccountEntity>
{
    public void Configure(EntityTypeBuilder<BankAccountEntity> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.AccountNumber).IsRequired();
    }
}
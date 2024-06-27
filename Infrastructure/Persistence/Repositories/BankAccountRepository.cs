using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.DataBases;

namespace Infrastructure.Persistence.Repositories;

public class BankAccountRepository : BaseRepository<BankAccountEntity>, IBankAccountRepository
{
    public BankAccountRepository(EFContext context) : base(context)
    {
    }
}
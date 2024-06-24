using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories;

public class BankAccountRepository : BaseRepository<BankAccountEntity>, IBankAccountRepository
{
    public BankAccountRepository(EFContext context) : base(context)
    {
    }
}

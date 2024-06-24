using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contracts.Requests.BankAccountRequests
{
    public record GetAllBankAccountRequestModel
    {
        public IEnumerable<Domain.Entities.BankAccountEntity> Items { get; init; } = Enumerable.Empty<Domain.Entities.BankAccountEntity>();
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contracts.Requests.BankAccountRequests
{
    public record GetAllBankAccountRequestModel
    {
        public IEnumerable<Domain.Entities.BankAccount> Items { get; init; } = Enumerable.Empty<Domain.Entities.BankAccount>();
    }
}

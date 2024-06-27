using Domain.Entities;

namespace Contracts.Requests.BankAccountRequests;

public record GetAllBankAccountRequestModel
{
    public IEnumerable<BankAccountEntity> Items { get; init; } = Enumerable.Empty<BankAccountEntity>();
}
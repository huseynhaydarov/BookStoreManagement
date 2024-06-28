using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.BankAccountRequests;
using Contracts.Responses;
using MediatR;


namespace Application.BankAccounts.Queries;

public record GetBankAccountsQuery : GetAllBankAccountRequestModel, IRequest<IReadOnlyCollection<BankAccountResponse>>;

public class GetBankAccountsQueryHandler(IMapper mapper, IBankAccountRepository accountRepository)
    : IRequestHandler<GetBankAccountsQuery, IReadOnlyCollection<BankAccountResponse>>
{
    public async Task<IReadOnlyCollection<BankAccountResponse>> Handle(GetBankAccountsQuery request,
        CancellationToken cancellationToken)
    {
        var authors = await accountRepository.GetAllAsync(request, cancellationToken);
        return mapper.Map<List<BankAccountResponse>>(authors);
    }
}

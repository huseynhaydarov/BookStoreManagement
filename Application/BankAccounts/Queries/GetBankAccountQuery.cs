using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Responses;
using Domain.Entities;
using MediatR;

namespace Application.BankAccounts.Queries;

public class GetBankAccountQuery(int id) : IRequest<BankAccountResponse>
{
    public int Id = id;
}

public class GetBookQueryHandler(IMapper mapper, IBankAccountRepository accountRepository) :
    IRequestHandler<GetBankAccountQuery, BankAccountResponse>
{
    private readonly IBankAccountRepository _accountRepository = accountRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<BankAccountResponse> Handle(GetBankAccountQuery request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetAsync(request.Id);

        if (account is null) throw new Exception($"Not found entity with the following id: {request.Id}");

        mapper.Map(request, account);
        return _mapper.Map<BankAccountEntity, BankAccountResponse>(account);
    }
}
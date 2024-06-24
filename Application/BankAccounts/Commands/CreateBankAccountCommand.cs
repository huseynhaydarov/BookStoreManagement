using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.BankAccount;
using Contracts.Requests.BookRequests;
using Contracts.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BankAccounts.Commands;

public record CreateBankAccountCommand : CreateBankAccountRequestModel, IRequest<BankAccountResponse>
{
}

public class CreateBankAccountCommandHandler(IMapper mapper, IBankAccountRepository accountRepository)
    : IRequestHandler<CreateBankAccountCommand, BankAccountResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly IBankAccountRepository _accountRepository = accountRepository;

    public async Task<BankAccountResponse> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
    {
        var entity = await _accountRepository.CreateAsync(_mapper.Map<BankAccountEntity>(request), cancellationToken);
        return _mapper.Map<BankAccountResponse>(entity);
    }
}

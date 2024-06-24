using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.BankAccountRequests;
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

public record UpdateBankAccountCommand : UpdateBankAccountRequestModel, IRequest<BankAccountResponse>
{
    public int Id { get; set; }
}
public class UpdateBankAccountCommandHandler : IRequestHandler<UpdateBankAccountCommand, BankAccountResponse>
{
    private readonly IMapper _mapper;
    private readonly IBankAccountRepository _accountRepository;

    public UpdateBankAccountCommandHandler(IMapper mapper, IBankAccountRepository accountRepository)
    {
        _mapper = mapper;
        _accountRepository = accountRepository;
    }

    public async Task<BankAccountResponse> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetAsync(request.Id, cancellationToken);

        if (account is null)
        {
            throw new Exception($"Not found entity with the following id: {request.Id}");
        }

        _mapper.Map(request, account);
        account = await _accountRepository.UpdateAsync(account);
        return _mapper.Map<BankAccountEntity, BankAccountResponse>(account);
    }
}
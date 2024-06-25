using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BankAccounts.Commands;

public record DeleteBankAccountCommand : IRequest<bool>
{
    public int Id { get; set; }
}
public class DeleteBankAccountCommandHandler : IRequestHandler<DeleteBankAccountCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IBankAccountRepository _accountRepository;

    public DeleteBankAccountCommandHandler(IMapper mapper, IBankAccountRepository accountRepository)
    {
        _mapper = mapper;
        _accountRepository = accountRepository;
    }

    public async Task<bool> Handle(DeleteBankAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetAsync(request.Id, cancellationToken);

        if (account is null)
        {
            throw new NotFoundException(nameof(account), request.Id);
        }

        await _accountRepository.DeleteAsync(account, cancellationToken);
        return true;
    }
}
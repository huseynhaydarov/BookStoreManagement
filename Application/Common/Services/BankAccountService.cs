using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Exceptions;
using AutoMapper;
using Contracts.Requests.AuthorRequests;
using Contracts.Requests.BankAccount;
using Contracts.Requests.BankAccountRequests;
using Contracts.Requests.BookRequests;
using Contracts.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services;

public class BankAccountService(IBankAccountRepository accountRepository, IMapper mapper) : IBankAccountService
{
    public async Task<BankAccountResponse> CreateAsync(CreateBankAccountRequestModel request, CancellationToken token = default)
    {
        var book = mapper.Map<BankAccount>(request);
        var response = await accountRepository.CreateAsync(book, token);
        return mapper.Map<BankAccountResponse>(response);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
    {
        var account = await accountRepository.GetAsync(id, token);

        if (account is null)
        {
            throw new NotFoundException(nameof(account), id);
        }
        return await accountRepository.DeleteAsync(account, token);
    }

    public async Task<List<BankAccountResponse>> GetAllAsync(CancellationToken token = default)
    {
        var response = await accountRepository.GetAllAsync(token);
        return mapper.Map<List<BankAccountResponse>>(response);
    }

    public async Task<BankAccountResponse?> GetAsync(int id, CancellationToken token = default)
    {
        var response = await accountRepository.GetAsync(id, token);

        if (response is null)
        {
            throw new NotFoundException(nameof(BankAccount), id);
        }
        return mapper.Map<BankAccountResponse?>(response);
    }

    public async Task UpdateAsync(int id, UpdateBankAccountRequestModel request, CancellationToken token = default)
    {
        var account = await accountRepository.GetAsync(id, token);

        if (account is null)
        {
            throw new Exception($"Not found entity with the following id: {id}");
        }
        mapper.Map<BankAccount>(request);
        await accountRepository.UpdateAsync(account, token);
    }
}

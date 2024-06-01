using Contracts.Requests.BankAccountRequests;
using Contracts.Requests.BookRequests;
using Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services;

public interface IBankAccountService
{
    Task<BankAccountResponse?> GetAsync(int id, CancellationToken token = default);

    Task<List<BankAccountResponse>> GetAllAsync(CancellationToken token = default);

    Task<BankAccountResponse> CreateAsync(CreateBookRequestsModel request, CancellationToken token = default);

    Task<bool> UpdateAsync(UpdateBankAccountRequestModel request, CancellationToken token = default);

    Task<bool> DeleteAsync(int id, CancellationToken token = default);
}

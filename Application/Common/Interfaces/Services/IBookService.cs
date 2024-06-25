﻿using Contracts.Requests.BookRequests;
using Contracts.Requests.CustomerRequests;
using Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services;

public interface IBookService
{
    Task<BankAccountResponse?> GetAsync(int id, CancellationToken token = default);

    Task<List<BankAccountResponse>> GetAllAsync(int pageSize, int pageNumber, CancellationToken token = default);

    Task<BankAccountResponse> CreateAsync(CreateBookRequestsModel request, CancellationToken token = default);

    Task UpdateAsync(int id, UpdateBookRequestModel request, CancellationToken token = default);

    Task<bool> DeleteAsync(int id, CancellationToken token = default);
}

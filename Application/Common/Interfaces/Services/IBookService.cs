using Contracts.Requests.BookRequests;
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
    Task<BookResponse?> GetAsync(int id, CancellationToken token = default);

    Task<List<BookResponse>> GetAllAsync(CancellationToken token = default);

    Task<BookResponse> CreateAsync(CreateBookRequestsModel request, CancellationToken token = default);

    Task<bool> UpdateAsync(UpdateBookRequestModel request, CancellationToken token = default);

    Task<bool> DeleteAsync(int id, CancellationToken token = default);
}

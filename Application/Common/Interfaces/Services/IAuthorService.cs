using Contracts.Requests.AuthorRequests;
using Contracts.Requests.BookRequests;
using Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services;

public interface IAuthorService
{
    Task<AuthorResponse?> GetAsync(int id, CancellationToken token = default);

    Task<List<AuthorResponse>> GetAllAsync(CancellationToken token = default);

    Task<AuthorResponse> CreateAsync(CreateAuthorRequestModel request, CancellationToken token = default);

    Task UpdateAsync(int id, UpdateAuthorRequestModel request, CancellationToken token = default);

    Task<bool> DeleteAsync(int id, CancellationToken token = default);
}

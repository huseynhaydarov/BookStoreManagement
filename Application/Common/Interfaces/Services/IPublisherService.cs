using Contracts.Requests.OrderRequests;
using Contracts.Requests.PublisherRequests;
using Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services;

public interface IPublisherService
{
    Task<PublisherResponse?> GetAsync(int id, CancellationToken token = default);

    Task<List<PublisherResponse>> GetAllAsync(CancellationToken token = default);

    Task<PublisherResponse> CreateAsync(CreatePublisherRequestModel request, CancellationToken token = default);

    Task<bool> UpdateAsync(UpdatePublisherRequestModel request, CancellationToken token = default);

    Task<bool> DeleteAsync(int id, CancellationToken token = default);
}

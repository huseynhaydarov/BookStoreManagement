using Contracts.Requests.OrderRequests;
using Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services;

public interface IOrderService
{
    Task<OrderResponse?> GetAsync(int id, CancellationToken token = default);

    Task<List<OrderResponse>> GetAllAsync(CancellationToken token = default);

    Task<OrderResponse> CreateAsync(CreateOrderRequestModel request, CancellationToken token = default);

    Task<bool> UpdateAsync(UpdateAuhtorRequestModel request, CancellationToken token = default);

    Task<bool> DeleteAsync(int id, CancellationToken token = default);
}

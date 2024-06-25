using Contracts.Requests.OrderItemRequestsModel;
using Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services;

public interface IOrderItemService
{
    Task<OrderItemResponse?> GetAsync(int id, CancellationToken token = default);

    Task<List<OrderItemResponse>> GetAllAsync(int pageSize, int pageNumber, CancellationToken token = default);

    Task<OrderItemResponse> CreateAsync(CreateOrderItemRequestModel request, CancellationToken token = default);

    Task UpdateAsync(int id, UpdateOrderItemRequestModel request, CancellationToken token = default);

    Task<bool> DeleteAsync(int id, CancellationToken token = default);
}

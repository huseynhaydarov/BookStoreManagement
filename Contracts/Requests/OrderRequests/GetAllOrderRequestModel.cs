using Domain.Entities;

namespace Contracts.Requests.OrderRequests;

public record GetAllOrderRequestModel
{
    public IEnumerable<OrderItemEntity> Items { get; init; } = Enumerable.Empty<OrderItemEntity>();
}
using Domain.Entities;

namespace Contracts.Requests.OrderItemRequestsModel;

public record GetAllOrderItemRequestModel
{
    public IEnumerable<OrderItemEntity> Items { get; init; } = Enumerable.Empty<OrderItemEntity>();
}
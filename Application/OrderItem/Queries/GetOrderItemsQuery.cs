using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.OrderItemRequestsModel;
using Contracts.Responses;
using MediatR;

namespace Application.OrderItem.Queries;

public record GetOrderItemsQuery : GetAllOrderItemRequestModel, IRequest<IReadOnlyCollection<OrderItemResponse>>;

public class GetOrderItemsQueryHandler(IMapper mapper, IOrderItemRepository orderItemRepository)
    : IRequestHandler<GetOrderItemsQuery, IReadOnlyCollection<OrderItemResponse>>
{
    public async Task<IReadOnlyCollection<OrderItemResponse>> Handle(GetOrderItemsQuery request,
        CancellationToken cancellationToken)
    {
        var authors = await orderItemRepository.GetAllAsync(request, cancellationToken);
        return mapper.Map<List<OrderItemResponse>>(authors);
    }
}

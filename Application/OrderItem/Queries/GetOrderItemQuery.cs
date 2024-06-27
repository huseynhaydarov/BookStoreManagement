using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Responses;
using Domain.Entities;
using MediatR;

namespace Application.OrderItem.Queries;

public class GetOrderItemQuery(int id) : IRequest<OrderItemResponse>
{
    public int Id = id;
}

public class GetOrderItemQueryHandler(IMapper mapper, IOrderItemRepository orderItemRepository) :
    IRequestHandler<GetOrderItemQuery, OrderItemResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly IOrderItemRepository _orderItemRepository = orderItemRepository;

    public async Task<OrderItemResponse> Handle(GetOrderItemQuery request, CancellationToken cancellationToken)
    {
        var orderItem = await _orderItemRepository.GetAsync(request.Id);

        if (orderItem is null) throw new Exception($"Not found entity with the following id: {request.Id}");
        mapper.Map(request, orderItem);
        return _mapper.Map<OrderItemEntity, OrderItemResponse>(orderItem);
    }
}
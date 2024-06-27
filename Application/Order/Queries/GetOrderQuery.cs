using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Order.Queries;

public class GetOrderQuery(int id) : IRequest<OrderResponse>
{
    public int Id = id;
}

public class GetOrderQueryHandler(IMapper mapper, IOrderRepository orderRepository) :
    IRequestHandler<GetOrderQuery, OrderResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<OrderResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetAsync(request.Id);

        if (order is null) throw new Exception($"Not found entity with the following id: {request.Id}");
        mapper.Map(request, order);
        return _mapper.Map<OrderEnitity, OrderResponse>(order);
    }
}
using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.OrderRequests;
using Contracts.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Order.Commands;

public record UpdateOrderCommand : UpdateOrderRequestModel, IRequest<OrderResponse>
{
    public int Id { get; set; }
}

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderResponse>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public UpdateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<OrderResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetAsync(request.Id, cancellationToken);

        if (order is null) throw new Exception($"Not found entity with the following id: {request.Id}");

        _mapper.Map(request, order);
        order = await _orderRepository.UpdateAsync(order);
        return _mapper.Map<OrderEnitity, OrderResponse>(order);
    }
}
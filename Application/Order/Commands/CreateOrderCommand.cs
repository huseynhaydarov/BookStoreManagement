using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.BookRequests;
using Contracts.Requests.OrderItemRequestsModel;
using Contracts.Requests.OrderRequests;
using Contracts.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Commands;

public record CreateOrderCommand : CreateOrderRequestModel, IRequest<OrderResponse>
{
}

public class CreateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository)
    : IRequestHandler<CreateOrderCommand, OrderResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<OrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _orderRepository.CreateAsync(_mapper.Map<OrderEnitity>(request), cancellationToken);
        return _mapper.Map<OrderResponse>(entity);
    }
}
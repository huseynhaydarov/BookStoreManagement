using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.OrderItemRequestsModel;
using Contracts.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderItem.Commands;

public record CreateOrderItemCommand : CreateOrderItemRequestModel, IRequest<OrderItemResponse>
{
}

public class CreateOrderItemCommandHandler(IMapper mapper, IOrderItemRepository orderItemRepository)
    : IRequestHandler<CreateOrderItemCommand, OrderItemResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly IOrderItemRepository _orderitemRepository = orderItemRepository;

    public async Task<OrderItemResponse> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _orderitemRepository.CreateAsync(_mapper.Map<OrderItemEntity>(request), cancellationToken);
        return _mapper.Map<OrderItemResponse>(entity);
    }
}
using Application.Common.Interfaces.Repositories;
using Application.Order.Commands;
using AutoMapper;
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

namespace Application.OrderItem.Commands;

public record UpdateOrderItemCommand : UpdateOrderItemRequestModel, IRequest<OrderItemResponse>
{
    public int Id { get; set; }
}
public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, OrderItemResponse>
{
    private readonly IMapper _mapper;
    private readonly IOrderItemRepository _orderItemRepository;

    public UpdateOrderItemCommandHandler(IMapper mapper, IOrderItemRepository orderItemRepository)
    {
        _mapper = mapper;
        _orderItemRepository = orderItemRepository;
    }

    public async Task<OrderItemResponse> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
    {
        var orderItem = await _orderItemRepository.GetAsync(request.Id, cancellationToken);

        if (orderItem is null)
        {
            throw new Exception($"Not found entity with the following id: {request.Id}");
        }

        _mapper.Map(request, orderItem);
        orderItem = await _orderItemRepository.UpdateAsync(orderItem);
        return _mapper.Map<OrderItemEntity, OrderItemResponse>(orderItem);
    }
}

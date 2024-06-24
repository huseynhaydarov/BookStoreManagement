using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderItem.Queries;

public class GetOrderItemQuery(int id) : IRequest<OrderItemResponse>
{
    public int Id = id;
}

public class GetOrderItemQueryHandler(IMapper mapper, IOrderItemRepository orderItemRepository) :
    IRequestHandler<GetOrderItemQuery, OrderItemResponse>
{
    private readonly IOrderItemRepository _orderItemRepository = orderItemRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<OrderItemResponse> Handle(GetOrderItemQuery request, CancellationToken cancellationToken)
    {
        var orderItem = await _orderItemRepository.GetAsync(request.Id);

        if (orderItem is null)
        {
            throw new Exception($"Not found entity with the following id: {request.Id}");
        }
        mapper.Map(request, orderItem);
        return _mapper.Map<OrderItemEntity, OrderItemResponse>(orderItem);
    }
}

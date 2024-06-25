using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderItem.Commands;

public record DeleteOrderItemCommand : IRequest<bool>
{
    public int Id { get; set; }
}
public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IOrderItemRepository _orderItemRepository;

    public DeleteOrderItemCommandHandler(IMapper mapper, IOrderItemRepository orderItemRepository)
    {
        _mapper = mapper;
        _orderItemRepository = orderItemRepository;
    }

    public async Task<bool> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
    {
        var orderItem = await _orderItemRepository.GetAsync(request.Id, cancellationToken);

        if (orderItem is null)
        {
            throw new NotFoundException(nameof(orderItem), request.Id);
        }

        await _orderItemRepository.DeleteAsync(orderItem, cancellationToken);
        return true;
    }
}

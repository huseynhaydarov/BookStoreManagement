using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Commands;

public record DeleteOrderCommand : IRequest<bool>
{
    public int Id { get; set; }
}
public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetAsync(request.Id, cancellationToken);

        if (order is null)
        {
            throw new NotFoundException(nameof(order), request.Id);
        }

        await _orderRepository.DeleteAsync(order, cancellationToken);
        return true;
    }
}
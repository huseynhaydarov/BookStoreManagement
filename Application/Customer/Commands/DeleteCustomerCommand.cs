using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customer.Commands;

public record DeleteCustomerCommand : IRequest<bool>
{
    public int Id { get; set; }
}
public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetAsync(request.Id, cancellationToken);

        if (customer is null)
        {
            throw new NotFoundException(nameof(customer), request.Id);
        }

        await _customerRepository.DeleteAsync(customer, cancellationToken);
        return true;
    }
}

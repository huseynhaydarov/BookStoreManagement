using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Customer.Commands;

public record DeleteCustomerCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public DeleteCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetAsync(request.Id, cancellationToken);

        if (customer is null) throw new NotFoundException(nameof(customer), request.Id);

        await _customerRepository.DeleteAsync(customer, cancellationToken);
        return true;
    }
}
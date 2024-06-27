using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.CustomerRequests;
using Contracts.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Customer.Commands;

public record UpdateCustomerCommand : UpdateCustomerRequestModel, IRequest<CustomerResponse>
{
    public int Id { get; set; }
}

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<CustomerResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetAsync(request.Id, cancellationToken);

        if (customer is null) throw new Exception($"Not found entity with the following id: {request.Id}");

        _mapper.Map(request, customer);
        customer = await _customerRepository.UpdateAsync(customer);
        return _mapper.Map<CustomerEntity, CustomerResponse>(customer);
    }
}
using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.CustomerRequests;
using Contracts.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Customer.Commands;

public record CreateCustomerCommand : CreateCustomerRequestModel, IRequest<CustomerResponse>
{
}

public class CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
    : IRequestHandler<CreateCustomerCommand, CustomerResponse>
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _customerRepository.CreateAsync(_mapper.Map<CustomerEntity>(request), cancellationToken);
        return _mapper.Map<CustomerResponse>(entity);
    }
}
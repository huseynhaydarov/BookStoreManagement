using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.BookRequests;
using Contracts.Requests.CustomerRequests;
using Contracts.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customer.Commands;

public record CreateCustomerCommand : CreateCustomerRequestModel, IRequest<CustomerResponse>
{
}

public class CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
    : IRequestHandler<CreateCustomerCommand, CustomerResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _customerRepository.CreateAsync(_mapper.Map<CustomerEntity>(request), cancellationToken);
        return _mapper.Map<CustomerResponse>(entity);
    }
}

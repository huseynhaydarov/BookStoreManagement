using Application.Common.Interfaces.Repositories;
using Application.Common.Services;
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

public record UpdateCustomerCommand : UpdateCustomerRequestModel, IRequest<CustomerResponse>
{
    public int Id { get; set; }
}
public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerResponse>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<CustomerResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetAsync(request.Id, cancellationToken);

        if (customer is null)
        {
            throw new Exception($"Not found entity with the following id: {request.Id}");
        }

        _mapper.Map(request, customer);
        customer = await _customerRepository.UpdateAsync(customer);
        return _mapper.Map<CustomerEntity, CustomerResponse>(customer);
    }
}
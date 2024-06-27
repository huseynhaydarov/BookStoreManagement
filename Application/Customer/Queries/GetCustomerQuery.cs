using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Customer.Queries;

public class GetCustomerQuery(int id) : IRequest<CustomerResponse>
{
    public int Id = id;
}

public class GetCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository) :
    IRequestHandler<GetCustomerQuery, CustomerResponse>
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CustomerResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetAsync(request.Id);

        if (customer is null) throw new Exception($"Not found entity with the following id: {request.Id}");
        mapper.Map(request, customer);
        return _mapper.Map<CustomerEntity, CustomerResponse>(customer);
    }
}
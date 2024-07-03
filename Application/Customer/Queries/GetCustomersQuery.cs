using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.CustomerRequests;
using Contracts.Responses;
using MediatR;

namespace Application.Customer.Queries;

public record GetCustomersQuery : GetAllCustomerRequestModel, IRequest<IReadOnlyCollection<CustomerResponse>>;

public class GetCustomersQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
    : IRequestHandler<GetCustomersQuery, IReadOnlyCollection<CustomerResponse>>
{
    public async Task<IReadOnlyCollection<CustomerResponse>> Handle(GetCustomersQuery request,
        CancellationToken cancellationToken)
    {
        var authors = await customerRepository.GetAllAsync(request, cancellationToken);
        return mapper.Map<List<CustomerResponse>>(authors);
    }
}
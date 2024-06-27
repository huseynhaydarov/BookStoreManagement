using Domain.Entities;

namespace Contracts.Requests.CustomerRequests;

public record GetAllCustomerRequestModel
{
    public IEnumerable<CustomerEntity> Items { get; init; } = Enumerable.Empty<CustomerEntity>();
}
using Contracts.Pagination;
using Domain.Entities;

namespace Contracts.Requests.CustomerRequests;

public record GetAllCustomerRequestModel : PagingParameters
{
}
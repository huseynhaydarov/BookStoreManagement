using Contracts.Pagination;
using Domain.Entities;

namespace Contracts.Requests.OrderRequests;

public record GetAllOrderRequestModel : PagingParameters
{
}
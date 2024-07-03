using Contracts.Pagination;
using Domain.Entities;

namespace Contracts.Requests.PublisherRequests;

public record GetAllPublisherRequestModel : PagingParameters
{
}
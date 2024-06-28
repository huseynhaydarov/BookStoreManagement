using Contracts.Pagination;
using Domain.Entities;

namespace Contracts.Requests.BookRequests;

public record GetAllBookRequestModel : PagingParameters
{
}
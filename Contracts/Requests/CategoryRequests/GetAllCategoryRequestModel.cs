using Contracts.Pagination;
using Domain.Entities;

namespace Contracts.Requests.CategoryRequests;

public record GetAllCategoryRequestModel : PagingParameters
{
}
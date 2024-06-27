using Domain.Entities;

namespace Contracts.Requests.CategoryRequests;

public record GetAllCategoryRequestModel
{
    public IEnumerable<CategoryEntity> Items { get; init; } = Enumerable.Empty<CategoryEntity>();
}
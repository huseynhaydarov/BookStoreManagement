namespace Contracts.Requests.CategoryRequests;

public record CreateCategoryRequestModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}
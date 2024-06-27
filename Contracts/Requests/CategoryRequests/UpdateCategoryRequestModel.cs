namespace Contracts.Requests.CategoryRequests;

public record UpdateCategoryRequestModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}
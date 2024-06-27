namespace Contracts.Requests.PublisherRequests;

public record UpdatePublisherRequestModel
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
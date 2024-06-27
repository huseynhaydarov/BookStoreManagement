namespace Contracts.Requests.CustomerRequests;

public record UpdateCustomerRequestModel
{
    public DateTime RegisteredDate { get; set; }
    public string Email { get; set; }
}
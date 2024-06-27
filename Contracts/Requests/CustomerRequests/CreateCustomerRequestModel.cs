namespace Contracts.Requests.CustomerRequests;

public record CreateCustomerRequestModel
{
    public DateTime RegisteredDate { get; set; }
    public string Email { get; set; }
}
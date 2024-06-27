namespace Contracts.Requests.BankAccountRequests;

public record UpdateBankAccountRequestModel
{
    public int AccountNumber { get; set; }

    public int CustomerId { get; set; }
}
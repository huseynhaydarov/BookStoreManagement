namespace Contracts.Requests.BankAccount;

public record CreateBankAccountRequestModel
{
    public int AccountNumber { get; set; }

    public int CustomerId { get; set; }
}
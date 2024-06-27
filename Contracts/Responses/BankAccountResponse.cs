namespace Contracts.Responses;

public record BankAccountResponse
{
    public int Id { get; set; }
    public int AccountNumber { get; set; }

    public int CustomerId { get; set; }
}
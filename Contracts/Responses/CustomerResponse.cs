namespace Contracts.Responses;

public record CustomerResponse
{
    public int Id { get; set; }
    public DateTime RegisteredDate { get; set; }
    public string Email { get; set; }
}
namespace Contracts.Responses;

public record AuthorResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Biography { get; set; }
}
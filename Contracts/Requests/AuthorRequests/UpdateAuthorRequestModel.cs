namespace Contracts.Requests.AuthorRequests;

public record UpdateAuthorRequestModel
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Biography { get; set; }
}
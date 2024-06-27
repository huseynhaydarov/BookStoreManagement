namespace Contracts.Requests.AuthorRequests;

public record CreateAuthorRequestModel
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Biography { get; set; }
}
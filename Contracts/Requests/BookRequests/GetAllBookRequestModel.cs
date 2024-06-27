using Domain.Entities;

namespace Contracts.Requests.BookRequests;

public record GetAllBookRequestModel
{
    public IEnumerable<BookEntity> Items { get; init; } = Enumerable.Empty<BookEntity>();
}
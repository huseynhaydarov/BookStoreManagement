using Domain.Entities;

namespace Contracts.Requests.PublisherRequests;

public record GetAllPublisherRequestModel
{
    public IEnumerable<PublisherEntity> Items { get; init; } = Enumerable.Empty<PublisherEntity>();
}
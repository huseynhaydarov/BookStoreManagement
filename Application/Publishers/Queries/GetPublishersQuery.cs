using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.PublisherRequests;
using Contracts.Responses;
using MediatR;

namespace Application.Publishers.Queries;

public record GetPublishersQuery : GetAllPublisherRequestModel, IRequest<IReadOnlyCollection<PublisherResponse>>;

public class GetPublishersQueryHandler(IMapper mapper, IPublisherRepository publisherRepository)
    : IRequestHandler<GetPublishersQuery, IReadOnlyCollection<PublisherResponse>>
{
    public async Task<IReadOnlyCollection<PublisherResponse>> Handle(GetPublishersQuery request,
        CancellationToken cancellationToken)
    {
        var authors = await publisherRepository.GetAllAsync(request, cancellationToken);
        return mapper.Map<List<PublisherResponse>>(authors);
    }
}

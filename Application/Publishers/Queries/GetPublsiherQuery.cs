using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Publishers.Queries;

public class GetPublisherQuery(int id) : IRequest<PublisherResponse>
{
    public int Id = id;
}

public class GetPublisherQueryHandler(IMapper mapper, IPublisherRepository publisherRepository) :
    IRequestHandler<GetPublisherQuery, PublisherResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublisherRepository _publisherRepository = publisherRepository;

    public async Task<PublisherResponse> Handle(GetPublisherQuery request, CancellationToken cancellationToken)
    {
        var publisher = await _publisherRepository.GetAsync(request.Id);

        if (publisher is null) throw new Exception($"Not found entity with the following id: {request.Id}");
        mapper.Map(request, publisher);
        return _mapper.Map<PublisherEntity, PublisherResponse>(publisher);
    }
}
using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.PublisherRequests;
using Contracts.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Publishers.Commands;

public record CreatePublisherCommand : CreatePublisherRequestModel, IRequest<PublisherResponse>
{
}

public class CreatePublisherCommandHandler(IMapper mapper, IPublisherRepository publsiherRepository)
    : IRequestHandler<CreatePublisherCommand, PublisherResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublisherRepository _publisherRepository = publsiherRepository;

    public async Task<PublisherResponse> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
    {
        var entity = await _publisherRepository.CreateAsync(_mapper.Map<PublisherEntity>(request), cancellationToken);
        return _mapper.Map<PublisherResponse>(entity);
    }
}
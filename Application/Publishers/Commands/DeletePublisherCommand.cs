using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Publishers.Commands;

public record DeletePublisherCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IPublisherRepository _publisherRepository;

    public DeletePublisherCommandHandler(IMapper mapper, IPublisherRepository publisherRepository)
    {
        _mapper = mapper;
        _publisherRepository = publisherRepository;
    }

    public async Task<bool> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
    {
        var publisher = await _publisherRepository.GetAsync(request.Id, cancellationToken);

        if (publisher is null) throw new NotFoundException(nameof(publisher), request.Id);

        await _publisherRepository.DeleteAsync(publisher, cancellationToken);
        return true;
    }
}
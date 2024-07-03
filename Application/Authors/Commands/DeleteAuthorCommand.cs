using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Authors.Commands;

public record DeleteAuthorCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public DeleteAuthorCommandHandler(IMapper mapper, IAuthorRepository authorRepository)
    {
        _mapper = mapper;
        _authorRepository = authorRepository;
    }

    public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetAsync(request.Id, cancellationToken);

        if (author is null) throw new NotFoundException(nameof(author), request.Id);

        await _authorRepository.DeleteAsync(author, cancellationToken);
        return true;
    }
}
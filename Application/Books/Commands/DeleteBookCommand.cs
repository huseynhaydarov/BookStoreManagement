using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Books.Commands;

public record DeleteBookCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public DeleteBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetAsync(request.Id, cancellationToken);

        if (book is null) throw new NotFoundException(nameof(book), request.Id);

        await _bookRepository.DeleteAsync(book, cancellationToken);
        return true;
    }
}
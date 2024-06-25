using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands;

public record DeleteBookCommand : IRequest<bool>
{
    public int Id { get; set; }
}
public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public DeleteBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetAsync(request.Id, cancellationToken);

        if (book is null)
        {
            throw new NotFoundException(nameof(book), request.Id);
        }

        await _bookRepository.DeleteAsync(book, cancellationToken);
        return true;
    }
}
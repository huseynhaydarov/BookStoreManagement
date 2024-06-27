using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.BookRequests;
using Contracts.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Book;

public record UpdateBookCommand : UpdateBookRequestModel, IRequest<BookResponse>
{
    public int Id { get; set; }
}

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookResponse>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    public async Task<BookResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetAsync(request.Id, cancellationToken);

        if (book is null) throw new Exception($"Not found entity with the following id: {request.Id}");

        _mapper.Map(request, book);
        book = await _bookRepository.UpdateAsync(book);
        return _mapper.Map<BookEntity, BookResponse>(book);
    }
}
using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.BookRequests;
using Contracts.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Book;

public record CreateBookCommand : CreateBookRequestsModel, IRequest<BookResponse>
{
}

public class CreateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
    : IRequestHandler<CreateBookCommand, BookResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly IBookRepository _bookRepository = bookRepository;

    public async Task<BookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var entity = await _bookRepository.CreateAsync(_mapper.Map<BookEntity>(request), cancellationToken);
        return _mapper.Map<BookResponse>(entity);
    }
}

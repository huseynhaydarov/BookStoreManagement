using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Books.Queries;

public class GetBookQuery(int id) : IRequest<BookResponse>
{
    public int Id = id;
}

public class GetBookQueryHandler(IMapper mapper, IBookRepository bookRepository) :
    IRequestHandler<GetBookQuery, BookResponse>
{
    private readonly IBookRepository _bookRepository = bookRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<BookResponse> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetAsync(request.Id);

        if (book is null) throw new Exception($"Not found entity with the following id: {request.Id}");

        mapper.Map(request, book);
        return _mapper.Map<BookEntity, BookResponse>(book);
    }
}
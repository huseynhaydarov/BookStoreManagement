using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.BookRequests;
using Contracts.Responses;
using MediatR;

namespace Application.Books.Queries;

public record GetBooksQuery : GetAllBookRequestModel, IRequest<IReadOnlyCollection<BookResponse>>;

public class GetBooksQueryHandler(IMapper mapper, IBookRepository bookRepository)
    : IRequestHandler<GetBooksQuery, IReadOnlyCollection<BookResponse>>
{
    public async Task<IReadOnlyCollection<BookResponse>> Handle(GetBooksQuery request,
        CancellationToken cancellationToken)
    {
        var authors = await bookRepository.GetAllAsync(request, cancellationToken);
        return mapper.Map<List<BookResponse>>(authors);
    }
}
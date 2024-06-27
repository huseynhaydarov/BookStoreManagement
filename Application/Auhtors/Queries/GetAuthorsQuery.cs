using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.AuthorRequests;
using Contracts.Responses;
using MediatR;

namespace Application.Auhtors.Queries;

public record GetAuthorsQuery : GetAllAuthorRequestModel, IRequest<IReadOnlyCollection<AuthorResponse>>;

public class GetAuthorsQueryHandler(IMapper mapper, IAuthorRepository authorRepository)
    : IRequestHandler<GetAuthorsQuery, IReadOnlyCollection<AuthorResponse>>
{
    public async Task<IReadOnlyCollection<AuthorResponse>> Handle(GetAuthorsQuery request,
        CancellationToken cancellationToken)
    {
        var authors = await authorRepository.GetAllAsync(request, cancellationToken);
        return mapper.Map<List<AuthorResponse>>(authors);
    }
}
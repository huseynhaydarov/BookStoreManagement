using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.AuthorRequests;
using Contracts.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auhtors.Queries;

public record GetAuthorsQuery(int PageNumber = 1, int PageSize = 10)
    : IRequest<IReadOnlyCollection<AuthorResponse>>;

public class GetAuthorsQueryHandler(IMapper mapper,IAuthorRepository authorRepository)
    : IRequestHandler<GetAuthorsQuery, IReadOnlyCollection<AuthorResponse>>
{
    private readonly IAuthorRepository _authorRepository = authorRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IReadOnlyCollection<AuthorResponse>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _authorRepository.GetAllAsync(request.PageNumber, request.PageSize, cancellationToken);
        return mapper.Map<List<AuthorResponse>>(authors);
    }
}

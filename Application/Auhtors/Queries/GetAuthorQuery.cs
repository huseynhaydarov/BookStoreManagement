using Application.Books.Queries;
using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auhtors.Queries;

public class GetAuthorQuery(int id) : IRequest<AuthorResponse>
{
    public int Id = id;
}

public class GetAuthorQueryHandler(IMapper mapper, IAuthorRepository authorRepository) :
    IRequestHandler<GetAuthorQuery, AuthorResponse>
{
    private readonly IAuthorRepository _authorRepository = authorRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<AuthorResponse> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetAsync(request.Id);

        if (author is null)
        {
            throw new Exception($"Not found entity with the following id: {request.Id}");
        }
        mapper.Map(request, author);
        return _mapper.Map<AuthorEntity, AuthorResponse>(author);
    }
}

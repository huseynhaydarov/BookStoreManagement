using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.AuthorRequests;
using Contracts.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auhtors.Commands;

public record UpdateAuthorCommand : UpdateAuthorRequestModel, IRequest<AuthorResponse>
{
    public int Id { get; set; }
}

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, AuthorResponse>
{
    
    private readonly IMapper _mapper;
    private readonly IAuthorRepository _authorRepository;

    public UpdateAuthorCommandHandler(IMapper mapper, IAuthorRepository authorRepository)
    {
        _mapper = mapper;
        _authorRepository = authorRepository;
    }

    public async Task<AuthorResponse> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author =  await _authorRepository.GetAsync(request.Id, cancellationToken);

        if(author is null)
        {
            throw new Exception($"Not found entity with the following id: {request.Id}"); 
        }
        _mapper.Map(request, author);
        author = await _authorRepository.UpdateAsync(author);
        return _mapper.Map<AuthorEntity, AuthorResponse>(author);

    }
}

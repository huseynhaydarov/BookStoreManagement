using Application.Authors.Commands;
using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using AutoMapper;
using Contracts.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands;

public record DeleteAuthorCommand : IRequest<bool>
{
    public int Id { get; set; }
}
public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
{
private readonly IMapper _mapper;
private readonly IAuthorRepository _authorRepository;

public DeleteAuthorCommandHandler(IMapper mapper, IAuthorRepository authorRepository)
{
    _mapper = mapper;
    _authorRepository = authorRepository;
}

public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
{
    var author = await _authorRepository.GetAsync(request.Id, cancellationToken);

    if (author is null)
    {
        throw new NotFoundException(nameof(author), request.Id);
    }

    await _authorRepository.DeleteAsync(author, cancellationToken);
    return true;
}
}
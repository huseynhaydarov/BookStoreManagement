using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.AuthorRequests;
using Contracts.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Auhtors.Commands;

public record CreateAuthorCommand : CreateAuthorRequestModel, IRequest<AuthorResponse>
{
}

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorResponse>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public CreateAuthorCommandHandler(IMapper mapper, IAuthorRepository authorRepository)
    {
        _mapper = mapper;
        _authorRepository = authorRepository;
    }

    public async Task<AuthorResponse> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<AuthorEntity>(request);

        // Ensure DateOfBirth is converted to UTC if it's unspecified
        if (entity.DateOfBirth.Kind == DateTimeKind.Unspecified)
            entity.DateOfBirth = DateTime.SpecifyKind(entity.DateOfBirth, DateTimeKind.Utc);

        entity = await _authorRepository.CreateAsync(entity, cancellationToken);
        return _mapper.Map<AuthorResponse>(entity);
    }
}
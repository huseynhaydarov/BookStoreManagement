using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Contracts.Requests.OrderRequests;
using Contracts.Requests.PublisherRequests;
using Contracts.Responses;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Publishers.Commands;

public record UpdatePublisherCommand : UpdatePublisherRequestModel, IRequest<PublisherResponse>
{
    public int Id { get; set; }
}
public class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommand, PublisherResponse>
{
    private readonly IMapper _mapper;
    private readonly IPublisherRepository _publisherRepository;

    public UpdatePublisherCommandHandler(IMapper mapper, IPublisherRepository publisherRepository)
    {
        _mapper = mapper;
        _publisherRepository = publisherRepository;
    }

    public async Task<PublisherResponse> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
    {
        var publsiher = await _publisherRepository.GetAsync(request.Id, cancellationToken);

        if (publsiher is null)
        {
            throw new Exception($"Not found entity with the following id: {request.Id}");
        }

        _mapper.Map(request, publsiher);
        publsiher = await _publisherRepository.UpdateAsync(publsiher);
        return _mapper.Map<PublisherEntity, PublisherResponse>(publsiher);
    }
}


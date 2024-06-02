using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Exceptions;
using AutoMapper;
using Contracts.Requests.PublisherRequests;
using Contracts.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services;

public class PublisherService(IPublisherRepository publisherRepository, IMapper mapper) : IPublisherService
{
    public async Task<PublisherResponse> CreateAsync(CreatePublisherRequestModel request, CancellationToken token = default)
    {
        var publisher = mapper.Map<Publisher>(request);
        var response = await publisherRepository.CreateAsync(publisher, token);
        return mapper.Map<PublisherResponse>(response);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
    {
        var publisher = await publisherRepository.GetAsync(id, token);

        if (publisher is null)
        {
            throw new NotFoundException(nameof(publisher), id); 
        }
        return await publisherRepository.DeleteAsync(publisher, token);
    }

    public async Task<List<PublisherResponse>> GetAllAsync(CancellationToken token = default)
    {
        var response = await publisherRepository.GetAllAsync(token);
        return mapper.Map<List<PublisherResponse>>(response);
    }

    public async Task<PublisherResponse?> GetAsync(int id, CancellationToken token = default)
    {
        var response = await publisherRepository.GetAsync(id, token);

        if (response is null)
        {
            throw new NotFoundException(nameof(Publisher), id);
        }
        return mapper.Map<PublisherResponse>(response); 
    }

    public async Task UpdateAsync(UpdatePublisherRequestModel request, CancellationToken token = default)
    {
        var publisher = await publisherRepository.GetAsync(request.Id, token);

        if(publisher is null)
         {
                throw new NotFoundException(nameof(Publisher), request.Id);
         }
        publisher = mapper.Map<Publisher>(request);
        await publisherRepository.UpdateAsync(publisher,token);
            
    }
}

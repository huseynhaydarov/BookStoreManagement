using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Exceptions;
using AutoMapper;
using Contracts.Requests.AuthorRequests;
using Contracts.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services;

public class AuthorService(IAuthorRepository authorRepository, IMapper mapper) : IAuthorService
{
    public async Task<AuthorResponse> CreateAsync(CreateAuthorRequestModel request, CancellationToken token = default)
    {
        var author = mapper.Map<Author>(request);
        var response = await authorRepository.CreateAsync(author, token);
        return mapper.Map<AuthorResponse>(response);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
    {
        var author = await authorRepository.GetAsync(id, token);
        
        if(author is null)
        {
            throw new NotFoundException(nameof(author), id);
        }
        return await authorRepository.DeleteAsync(author, token);
    }

    public async Task<List<AuthorResponse>> GetAllAsync(CancellationToken token = default)
    {
        var response = await authorRepository.GetAllAsync(token);
        return mapper.Map<List<AuthorResponse>>(response);
    }

    public async Task<AuthorResponse?> GetAsync(int id, CancellationToken token = default)
        {
            var response = await authorRepository.GetAsync(id, token);

        if (response is null)
        {
            throw new NotFoundException(nameof(Author), id);
        } 
        return mapper.Map<AuthorResponse?>(response);
        }

    public async Task UpdateAsync(int id, UpdateAuthorRequestModel request, CancellationToken token = default)
    {
        var author = await authorRepository.GetAsync(id, token);

        if (author is null)
        {
            throw new Exception($"Not found entity with the following id: {id}");
        }
        mapper.Map<Author>(request);
        await authorRepository.UpdateAsync(author, token);
    }
}

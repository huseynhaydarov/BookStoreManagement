using Application.Common.Interfaces.Repositories;
using Contracts.Pagination;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories;

public class CachedBookRepository : IBookRepository
{
    private readonly IBookRepository _decorator;
    private readonly IMemoryCache _memoryCache;

    public CachedBookRepository(IBookRepository decorator, IMemoryCache memoryCache)
    {
        _decorator = decorator;
        _memoryCache = memoryCache;
    }

    public Task<BookEntity> CreateAsync(BookEntity entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(BookEntity entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookEntity>> GetAllAsync(PagingParameters parameters, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<BookEntity> GetAsync(int id, CancellationToken token = default)
    {
        string key = $"book-{id}";

        return _memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                return _decorator.GetAsync(id, token);
            });
       
        
    }

    public Task<BookEntity> UpdateAsync(BookEntity entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}

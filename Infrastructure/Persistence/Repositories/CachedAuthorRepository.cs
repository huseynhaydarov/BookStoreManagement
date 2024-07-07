using Application.Common.Interfaces.Repositories;
using Contracts.Pagination;
using Domain.Entities;
using Infrastructure.Persistence.DataBases;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;


namespace Infrastructure.Persistence.Repositories;

public class CachedAuthorRepository : IAuthorRepository
{
    private readonly IAuthorRepository _decorated;
    private readonly IDistributedCache _distributedCache;
    private readonly EFContext _dbcontext;

    public CachedAuthorRepository(IAuthorRepository decorated, IDistributedCache distributedCache, EFContext dbcontext)
    {
        _decorated = decorated;
        _distributedCache = distributedCache;
        _dbcontext = dbcontext;
    }

    public Task<AuthorEntity> CreateAsync(AuthorEntity entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(AuthorEntity entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AuthorEntity>> GetAllAsync(PagingParameters parameters, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthorEntity> GetAsync(int id, CancellationToken token = default)
    {
        string key = $"author-{id}";

        string? cachedAuthor = await _distributedCache.GetStringAsync(
            key,
            token);

        AuthorEntity? author;
        if (string.IsNullOrEmpty(cachedAuthor))
        {
            author = await _decorated.GetAsync(id, token);

            if (author == null)
            {
                return author;
            }

            await _distributedCache.SetStringAsync(
                key,
                JsonConvert.SerializeObject(author), token);

            return author;
              
        }
        author = JsonConvert.DeserializeObject<AuthorEntity>(cachedAuthor,
            new JsonSerializerSettings
            {
                ConstructorHandling = 
                ConstructorHandling.AllowNonPublicDefaultConstructor
            });
        if (author is not null)
        {
            _dbcontext.Set<AuthorEntity>().Attach(author);
        }
        
        return author;
    }

    public Task<AuthorEntity> UpdateAsync(AuthorEntity entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}

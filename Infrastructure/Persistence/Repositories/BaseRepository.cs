using Application.Common.Interfaces.Repositories;
using Contracts.Pagination;
using Domain.Abstract;
using Infrastructure.Persistence.DataBases;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly EFContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(EFContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken token = default)
    {
        await _dbSet.AddAsync(entity, token);
        await _context.SaveChangesAsync(token);
        return entity;
    }

    public async Task<bool> DeleteAsync(TEntity entity, CancellationToken token = default)
    {
        _dbSet.Remove(entity);
        return await _context.SaveChangesAsync(token) > 0;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(PagingParameters request, CancellationToken token = default)
    {
        IQueryable<TEntity> entities = _dbSet;

        if (request.OrderByDescending)
        {
            entities = entities.OrderByDescending(e => e.Id);
        }

        entities = entities.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize);

        return await entities.ToListAsync(token);
    }

    public async Task<TEntity> GetAsync(int id, CancellationToken token = default)
    {
        var entity = await _dbSet.FindAsync(id, token);

        if (entity is null)
            throw new Exception($"Not found entity with the following id: {id}");

        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token = default)
    {
        entity = _dbSet.Update(entity).Entity;
        await _context.SaveChangesAsync(token);
        return entity;
    }
}
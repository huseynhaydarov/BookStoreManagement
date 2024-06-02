using Application.Common.Interfaces.Repositories;
using Application.Exceptions;
using Domain.Abstract;
using Infrastructure.Persistence.DataBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token = default)
    {
        return await _dbSet.ToListAsync(token);
    }

    public async Task<TEntity> GetAsync(int id, CancellationToken token = default)
    {
        var entity = await _dbSet.FindAsync(id, token);

        if (entity is null)
            throw new Exception($"Not found entity with the following id: {id}");

        return entity;
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken token = default)
    {
        _dbSet.Update(entity);
         await _context.SaveChangesAsync(token);
    }
}

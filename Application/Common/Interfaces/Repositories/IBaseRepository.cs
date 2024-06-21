using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetAsync(int id, CancellationToken token = default);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token = default);
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken token = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token = default);
    Task<bool> DeleteAsync(TEntity entity, CancellationToken token = default);
}

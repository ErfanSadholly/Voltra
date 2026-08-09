using Domain;

namespace Application.IRepositories.Common;

public interface IGenericRepository<TEntity, TId> : IGenericBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : struct
{
    Task<bool> AddAsync(TEntity entity, int userId);
    Task<bool> UpdateAsync(TEntity entity, int userId);
    Task<bool> DeleteAsync(TEntity entity, int userId);
}
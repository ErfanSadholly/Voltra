namespace Application.Commons;

public interface IGenericRepository<TEntity, TId> 
{
    Task<bool> AddAsync(TEntity entity, int userId);
    Task<bool> UpdateAsync(TEntity entity, int userId);
    Task<bool> DeleteAsync(TEntity entity, int userId);
}
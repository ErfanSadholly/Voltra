namespace Application.IRepositories.Common;

public interface IGenericBaseRepository<TEntity, TId>
{
    Task<bool> IsExistAsync(TId id);
    Task<TEntity?> GetByIdAsync(TId id);
}
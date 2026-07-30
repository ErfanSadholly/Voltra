namespace Application.Commons;

public interface IGenericBaseRepository<TEntity, TId> where TId : struct
{
    Task<bool> IsExistAsync(TId id);
    Task<TEntity?> GetByIdAsync(TId id);
}
using Application.Commons;
using Domain;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories.Commons;

public class GenericRepository<TEntity, TId> : GenericBaseRepository<TEntity, TId>, IGenericRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : struct
{
    public GenericRepository(MainDbContext Context) : base(Context)
    {
    }

    public async Task<bool> AddAsync(TEntity entity, int userId)
    {
        entity.CreatedBy = userId;
        entity.CreatedOn = DateTime.Now;
        entity.IsDeleted = false;
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(TEntity entity, int userId)
    {
        entity.ModifiedBy = userId;
        entity.ModifiedOn = DateTime.Now;
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(TEntity entity, int userId)
    {
        entity.ModifiedBy = userId;
        entity.ModifiedOn = DateTime.Now;
        entity.IsDeleted = true;
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}

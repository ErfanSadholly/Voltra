using Application.IRepositories.Common;
using Domain;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Commons;

public class GenericBaseRepository<TEntity, TId> : IGenericBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
    where TId : struct
{
    protected readonly MainDbContext _context;
    public GenericBaseRepository(MainDbContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(i => i.Id.Equals(id));
    }

    public Task<bool> IsExistAsync(TId id)
    {
        return _context.Set<TEntity>().AnyAsync(i => i.Id.Equals(id));
    }
}

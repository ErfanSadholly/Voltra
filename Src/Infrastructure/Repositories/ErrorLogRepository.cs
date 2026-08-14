using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class ErrorLogRepository(MainDbContext _context) : IErrorLogRepository
{
    public async Task<long> AddAsync(ErrorLog entity, int? userId)
    {
        entity.UserId = userId;
        entity.CreatedOn = DateTime.Now;
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }
}

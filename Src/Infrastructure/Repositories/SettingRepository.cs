using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SettingRepository : GenericRepository<Setting, int>, ISettingRepository
{
    public SettingRepository(MainDbContext Context) : base(Context)
    {
    }

    public Task<string?> GetValueByKey(string key)
    {
        return _context.Settings
            .Where(i => i.Key == key)
            .Select(i => i.Value)
            .FirstOrDefaultAsync();
    }

    public Task<Setting?> GetSettingByKey(string key)
    {
        return _context.Settings.FirstOrDefaultAsync(i => i.Key == key);
    }
  
    public Task<Setting?> GetSettingIgnoreFiltersByKey(string key)
    {
        return _context.Settings.IgnoreQueryFilters().FirstOrDefaultAsync(i => i.Key == key);
    }
}

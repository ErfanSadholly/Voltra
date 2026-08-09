using Application.IRepositories.Common;
using Domain.Entities;

namespace Application.IRepositories;

public interface ISettingRepository : IGenericRepository<Setting, int>
{
    Task<string?> GetValueByKey(string key);
    Task<Setting?> GetSettingByKey(string key);
    Task<Setting?> GetSettingIgnoreFiltersByKey(string key);
}

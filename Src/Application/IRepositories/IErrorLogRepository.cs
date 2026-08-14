using Domain.Entities;

namespace Application.IRepositories;

public interface IErrorLogRepository
{
    Task<long> AddAsync(ErrorLog entity, int? userId);
}

using Application.Features;
using Application.IRepositories.Common;
using Domain.Entities;

namespace Application.IRepositories;

public interface IBrandRepository : IGenericRepository<Brand, int>
{
    Task<Brand_GetById_Response?> GetBrandById(int id);
    Task<PagedResult<Brand_GetAll_Response>> GetAllAsync(Brand_GetAll_Request request);
}

using Application.Features;
using Application.IRepositories.Common;
using Domain.Entities;

namespace Application.IRepositories;

public interface IProductRepository : IGenericRepository<Product, int>
{
    Task<Product_GetById_Response?> GetProductById(int id);
    Task<PagedResult<Product_GetAll_Response>> GetAllAsync(Product_GetAll_Request request);
}

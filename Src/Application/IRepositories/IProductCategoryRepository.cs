using Application.Features;
using Application.IRepositories.Common;
using Domain.Entities;

namespace Application.IRepositories;

public interface IProductCategoryRepository : IGenericRepository<ProductCategory, int>
{
	Task<bool> ExistProductInCategory(int productId, int categoryId);
	Task<bool> HasProducts(int categoryId);
	Task<List<ProductCategory_GetByProductId_Response>> GetByProductId(int productId);
}

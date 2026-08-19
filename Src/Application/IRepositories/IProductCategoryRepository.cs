using Application.IRepositories.Common;
using Domain.Entities;

namespace Application.IRepositories;

public interface IProductCategoryRepository : IGenericRepository<ProductCategory, int>
{
	Task<bool> ExistProductInCategory(int productId, int categoryId);
	Task<bool> HasProducts(int categoryId);
}

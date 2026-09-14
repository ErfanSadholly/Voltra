using Application.Features;
using Application.IRepositories.Common;
using Domain.Entities;

namespace Application.IRepositories;

public interface IProductInventoryRepository : IGenericRepository<ProductInventory, int>
{
	Task<ProductInventory_GetByProductId_Response?> GetByProductId(int productId);
	Task<bool> IsExistInventoryByProductId(int productId);
}

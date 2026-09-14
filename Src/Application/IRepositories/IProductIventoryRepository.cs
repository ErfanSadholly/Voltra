using Application.Features;
using Application.IRepositories.Common;
using Domain.Entities;

namespace Application.IRepositories;

public interface IProductIventoryRepository : IGenericRepository<ProductIventory, int>
{
	Task<ProductIventory_GetByProductId_Response?> GetByProductId(int productId);
	Task<bool> IsExistIventoryByProductId(int productId);
}

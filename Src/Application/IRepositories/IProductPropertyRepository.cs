using Application.Features;
using Application.IRepositories.Common;
using Domain.Entities;

namespace Application.IRepositories;

public interface IProductPropertyRepository : IGenericRepository<ProductProperty, int>
{
	Task<List<ProductProperty_GetByProductId_Response>> GetByProductId(int productId);
}

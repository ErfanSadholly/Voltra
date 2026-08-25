using Application.Features;
using Application.IRepositories.Common;
using Domain.Entities;

namespace Application.IRepositories;

public interface IProductPriceRepository : IGenericRepository<ProductPrice, int>
{
	Task<PagedResult<ProductPrice_GetAll_Response>> GetAllAsync(ProductPrice_GetAll_Request request);
}

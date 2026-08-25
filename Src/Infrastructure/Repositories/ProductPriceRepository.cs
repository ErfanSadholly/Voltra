using Application.Features;
using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductPriceRepository : GenericRepository<ProductPrice, int>, IProductPriceRepository
{
	public ProductPriceRepository(MainDbContext Context) : base(Context)
	{
	}

	public async Task<PagedResult<ProductPrice_GetAll_Response>> GetAllAsync(ProductPrice_GetAll_Request request)
	{
		var query = _context.ProductPrices.AsQueryable();

		if (request.ProductId is not null)
			query = query.Where(i => i.ProductId == request.ProductId);

		var totalCount = await query.CountAsync();

		query = query.OrderByDescending(i => i.CreatedOn);

		query = query.UsePagination(request);

		var res = await query.Select(i => new ProductPrice_GetAll_Response
		{
			Id = i.Id,
			ProductId = i.ProductId,
			ProductName = i.Product.Name,
			Price = i.Price,
			CreatedBy = i.CreatedByUser.FullName,
			CreatedOn = i.CreatedOn,
			ModifiedBy = i.ModifiedByUser.FullName,
			ModifiedOn = i.ModifiedOn,
		}).ToListAsync();

		return PagedResult<ProductPrice_GetAll_Response>.SuccessRes(res, totalCount);
	}
}

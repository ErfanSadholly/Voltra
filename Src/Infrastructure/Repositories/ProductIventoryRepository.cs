using Application.Features;
using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductIventoryRepository : GenericRepository<ProductIventory, int>, IProductIventoryRepository
{
	public ProductIventoryRepository(MainDbContext Context) : base(Context)
	{
	}

	public Task<ProductIventory_GetByProductId_Response?> GetByProductId(int productId)
	{
		return _context.ProductIventories
			.Where(i => i.ProductId == productId)
			.Select(i => new ProductIventory_GetByProductId_Response
			{
				Id = i.Id,
				ProductId = i.ProductId,
				ProductName = i.Product.Name,
				Quantity = i.Quantity,
				CreatedBy = i.CreatedByUser!.FullName,
				CreatedOn = i.CreatedOn,
				ModifiedBy = i.ModifiedByUser!.FullName,
				ModifiedOn = i.ModifiedOn,
			}).SingleOrDefaultAsync();
	}

	public Task<bool> IsExistIventoryByProductId(int productId)
	{
		return _context.ProductIventories.AnyAsync(i => i.ProductId == productId);
	}
}
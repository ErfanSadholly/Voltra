using Application.Features;
using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductInventoryRepository : GenericRepository<ProductInventory, int>, IProductInventoryRepository
{
	public ProductInventoryRepository(MainDbContext Context) : base(Context)
	{
	}

	public Task<ProductInventory_GetByProductId_Response?> GetByProductId(int productId)
	{
		return _context.ProductInventories
			.Where(i => i.ProductId == productId)
			.Select(i => new ProductInventory_GetByProductId_Response
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

	public Task<bool> IsExistInventoryByProductId(int productId)
	{
		return _context.ProductInventories.AnyAsync(i => i.ProductId == productId);
	}
}
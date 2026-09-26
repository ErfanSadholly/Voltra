using Application.Features;
using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductCategoryRepository : GenericRepository<ProductCategory, int>, IProductCategoryRepository
{
	public ProductCategoryRepository(MainDbContext Context) : base(Context)
	{
	}

	public Task<bool> ExistProductInCategory(int productId, int categoryId)
	{
		return _context.ProductCategories.AnyAsync(i => i.ProductId == productId && i.CategoryId == categoryId);
	}

	public Task<bool> HasProducts(int categoryId)
	{
		return _context.ProductCategories.AnyAsync(i => i.CategoryId == categoryId);
	}

	public Task<List<ProductCategory_GetByProductId_Response>> GetByProductId(int productId)
	{
		return _context.ProductCategories
			.Where(i => i.ProductId == productId)
			.Select(i => new ProductCategory_GetByProductId_Response
			{
				Id = i.Id,
				CategoryId = i.CategoryId,
				CategoryName = i.Category.Name,
				CreatedBy = i.CreatedByUser!.FullName,
				CreatedOn = i.CreatedOn,
				ModifiedBy = i.ModifiedByUser!.FullName,
				ModifiedOn = i.ModifiedOn
			}).ToListAsync();
	}
}
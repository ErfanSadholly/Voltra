using Application.Features;
using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductPropertyRepository : GenericRepository<ProductProperty, int>, IProductPropertyRepository
{
	public ProductPropertyRepository(MainDbContext Context) : base(Context)
	{
	}

	public Task<List<ProductProperty_GetByProductId_Response>> GetByProductId(int productId)
	{
		return _context.ProductProperties
			.Where(i => i.ProductId == productId)
			.Select(i => new ProductProperty_GetByProductId_Response
			{
				Id = i.Id,
				ProductId = i.ProductId,
				ProductName = i.Product.Name,
				Key = i.Key,
				Value = i.Value,
				CreatedBy = i.CreatedByUser!.FullName,
				CreatedOn = i.CreatedOn,
				ModifiedBy = i.ModifiedByUser!.FullName,
				ModifiedOn = i.ModifiedOn,
			}).ToListAsync();
	}
}

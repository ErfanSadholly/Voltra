using Application.Features;
using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductGalleryRepository : GenericRepository<ProductGallery, int>, IProductGalleryRepository
{
	public ProductGalleryRepository(MainDbContext Context) : base(Context)
	{
	}

	public Task<List<ProductGallery_GetById_Response>> GetByProductId(int productId)
	{
		return _context.ProductGalleries
			.Where(i => i.ProductId == productId)
			.Select(i => new ProductGallery_GetById_Response
			{
				Id = i.Id,
				ProductId = i.ProductId,
				ProductName = i.Product.Name,
				FileId = i.FileId,
				Order = i.Order,
				CreatedBy = i.CreatedByUser!.FullName,
				CreatedOn = i.CreatedOn,
				ModifiedBy = i.ModifiedByUser!.FullName,
				ModifiedOn = i.ModifiedOn
			}).ToListAsync();
	}
}

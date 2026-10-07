using Application.Features;
using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product, int>, IProductRepository
{
	public ProductRepository(MainDbContext Context) : base(Context)
	{
	}

	public Task<Product_GetById_Response?> GetProductById(int id)
	{
		return _context.Products
			.Where(i => i.Id == id)
			.Select(i => new Product_GetById_Response()
			{
				Id = i.Id,
				Name = i.Name,
				Description = i.Description,
				BrandId = i.BrandId,
				BrandName = i.Brand!.Name,
				IsActive = i.IsActive,
				CreatedBy = i.CreatedByUser!.FullName,
				CreatedOn = i.CreatedOn,
				ModifiedBy = i.ModifiedByUser!.FullName,
				ModifiedOn = i.ModifiedOn,
			}).FirstOrDefaultAsync();
	}

	public async Task<PagedResult<Product_GetAll_Response>> GetAllAsync(Product_GetAll_Request request)
	{
		var query = _context.Products.AsQueryable();

		if (!string.IsNullOrWhiteSpace(request.Name))
			query = query.Where(i => i.Name.Contains(request.Name));

		if (request.BrandId is not null)
			query = query.Where(i => i.BrandId == request.BrandId);

		if (request.CreatedBy is not null)
			query = query.Where(i => i.CreatedBy == request.CreatedBy);

		if (request.ModifiedBy is not null)
			query = query.Where(i => i.ModifiedBy == request.ModifiedBy);

		if (request.CreatedOn.HasValue)	
		{
			query = query.Where(x =>
			x.CreatedOn >= request.CreatedOn.Value.WithMinTime() &&
			x.CreatedOn <= request.CreatedOn.Value.WithMaxTime());
		}

		if (request.ModifiedOn.HasValue)
		{
			query = query.Where(x =>
			x.ModifiedOn >= request.ModifiedOn.Value.WithMinTime() &&
			x.ModifiedOn <= request.ModifiedOn.Value.WithMaxTime());
		}

		var totalCount = await query.CountAsync();


		query = request.SortBy switch
		{
			"name" => request.Desc
				? query.OrderByDescending(x => x.Name)
				: query.OrderBy(x => x.Name),

			"brandId" => request.Desc
				? query.OrderByDescending(x => x.Brand!.Name)
				: query.OrderBy(x => x.Brand!.Name),

			"isActive" => request.Desc
				? query.OrderByDescending(x => x.IsActive)
				: query.OrderBy(x => x.IsActive),

			"createdOn" => request.Desc
				? query.OrderByDescending(x => x.CreatedOn)
				: query.OrderBy(x => x.CreatedOn),

			"modifiedOn" => request.Desc
				? query.OrderByDescending(x => x.ModifiedOn)
				: query.OrderBy(x => x.ModifiedOn),

			_ => query.OrderByDescending(x => x.CreatedOn)
		};

		query = query.UsePagination(request);

		var res = await query.Select(i => new Product_GetAll_Response
		{
			Id = i.Id,
			Name = i.Name,
			Description = i.Description,
			BrandId = i.BrandId,
			BrandName = i.Brand!.Name,
			FileIds = i.ProductGallery.Select(i => i.FileId).ToList(),
			IsActive = i.IsActive,
			CreatedBy = i.CreatedByUser!.FullName,
			CreatedOn = i.CreatedOn,
			ModifiedBy = i.ModifiedByUser!.FullName,
			ModifiedOn = i.ModifiedOn,
		}).ToListAsync();

		return PagedResult<Product_GetAll_Response>.SuccessRes(res, totalCount);
	}

	public Task<Product_GetDetails_Response?> GetDetails(int productId)
	{
		return _context.Products
			.Where(i => i.Id == productId)
			.Select(i => new Product_GetDetails_Response
			{
				Product = new Product_GetAll_Response
				{
					Id = productId,
					Name = i.Name,
					Description = i.Description,
					BrandId = i.BrandId,
					BrandName = i.Brand!.Name,
					IsActive = i.IsActive,
					CreatedBy = i.CreatedByUser!.FullName,
					CreatedOn = i.CreatedOn,
					ModifiedBy = i.ModifiedByUser!.FullName,
					ModifiedOn = i.ModifiedOn,
				},

				ProductGalleries = i.ProductGallery.Select(pg => new ProductGallery_GetById_Response
				{
					Id = pg.Id,
					ProductId = pg.Product.Id,
					ProductName = pg.Product.Name,
					FileId = pg.FileId,
					Order = pg.Order,
					CreatedBy = pg.CreatedByUser!.FullName,
					CreatedOn = pg.CreatedOn,
					ModifiedBy = pg.ModifiedByUser!.FullName,
					ModifiedOn = pg.ModifiedOn,
				}).ToList(),

				ProductInventory = i.ProductInventory == null ? null
				: new ProductInventory_GetByProductId_Response
				{
					Id = i.ProductInventory.Id,
					ProductId = productId,
					ProductName = i.ProductInventory.Product.Name,
					Quantity = i.ProductInventory.Quantity,
					CreatedBy = i.ProductInventory.CreatedByUser!.FullName,
					CreatedOn = i.ProductInventory.CreatedOn,
					ModifiedBy = i.ProductInventory.ModifiedByUser!.FullName,
					ModifiedOn = i.ProductInventory.ModifiedOn,
				},

				ProductPrice = i.ProductPrices.Select(pp => new ProductPrice_GetAll_Response
				{
					Id = pp.Id,
					ProductId = productId,
					ProductName = pp.Product.Name,
					Price = pp.Price,
					CreatedBy = pp.CreatedByUser!.FullName,
					CreatedOn = pp.CreatedOn,
					ModifiedBy = pp.ModifiedByUser!.FullName,
					ModifiedOn = pp.ModifiedOn,
				}).ToList(),

				ProductProperties = i.ProductProperties.Select(prop => new ProductProperty_GetByProductId_Response
				{
					Id = prop.Id,
					ProductId = productId,
					ProductName = prop.Product.Name,
					Key = prop.Key,
					Value = prop.Value,
					CreatedBy = prop.CreatedByUser!.FullName,
					CreatedOn = prop.CreatedOn,
					ModifiedBy = prop.ModifiedByUser!.FullName,
					ModifiedOn = prop.ModifiedOn,
				}).ToList(),

				ProductCategories = _context.ProductCategories
				.Where(pc => pc.ProductId == productId)
				.Select(pc => new ProductCategory_GetByProductId_Response
				{
					Id = pc.Id,
					CategoryId = pc.Category.Id,
					CategoryName = pc.Category.Name,
					CreatedBy = pc.CreatedByUser!.FullName,
					CreatedOn = pc.CreatedOn,
					ModifiedBy = pc.ModifiedByUser!.FullName,
					ModifiedOn = pc.ModifiedOn,
				}).ToList()
			}).AsSplitQuery()
			.FirstOrDefaultAsync();
	}
}

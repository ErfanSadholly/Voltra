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

        var totalCount = await query.CountAsync();

        query = query.OrderByDescending(i => i.CreatedOn);

        query = query.UsePagination(request);

        var res = await query.Select(i => new Product_GetAll_Response
        {
            Id = i.Id,
            Name = i.Name,
            Description = i.Description,
            BrandId = i.BrandId,
            IsActive = i.IsActive,
            CreatedBy = i.CreatedByUser!.FullName,
            CreatedOn = i.CreatedOn,
            ModifiedBy = i.ModifiedByUser!.FullName,
            ModifiedOn = i.ModifiedOn,
        }).ToListAsync();

        return PagedResult<Product_GetAll_Response>.SuccessRes(res, totalCount);
    }
}

using Application.Features;
using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Common;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BrandRepository : GenericRepository<Brand, int>, IBrandRepository
{
    public BrandRepository(MainDbContext Context) : base(Context)
    {
    }

    public Task<Brand_GetById_Response?> GetBrandById(int id)
    {
        return _context.Brands
            .Where(i => i.Id == id)
            .Select(i => new Brand_GetById_Response
            {
                Id = i.Id,
                Name = i.Name,
                LogoUrl = i.LogoUrl,
                CreatedBy = i.CreatedByUser!.FullName,
                CreatedOn = i.CreatedOn,
                ModifiedBy = i.ModifiedByUser!.FullName,
                ModifiedOn = i.ModifiedOn,
            }).FirstOrDefaultAsync();
    }

    public async Task<PagedResult<Brand_GetAll_Response>> GetAllAsync(Brand_GetAll_Request request)
    {
        var query = _context.Brands.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Name))
            query = query.Where(i => i.Name.Contains(request.Name));

        var totalCount = await query.CountAsync();

        query = query.OrderByDescending(i => i.CreatedOn);

        query = query.UsePagination(request);

        var res = await query.Select(i => new Brand_GetAll_Response
        {
            Id = i.Id,
            Name = i.Name,
            LogoUrl = i.LogoUrl,
            CreatedBy = i.CreatedByUser!.FullName,
            CreatedOn = i.CreatedOn,
            ModifiedBy = i.ModifiedByUser!.FullName,
            ModifiedOn = i.ModifiedOn,
        }).ToListAsync();

        return PagedResult<Brand_GetAll_Response>.SuccessRes(res, totalCount);
    }
}

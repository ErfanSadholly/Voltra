using Application.Features.CategoryFeature;
using Application.IRepositories;
using Domain.Commons;
using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CategoryRepository : GenericRepository<Category, int>, ICategoryRepository
{
	public CategoryRepository(MainDbContext Context) : base(Context)
	{
	}

	public Task<bool> HasChildren(int id)
	{
		return _context.Categories.AnyAsync(i => i.ParentId == id);
	}

	public Task<GetIdTitle<int>?> GetCategoryById(int id)
	{
		return _context.Categories
			.Where(i => i.Id == id)
			.Select(i => new GetIdTitle<int>
			{
				Id = i.Id,
				Title = i.Name,
			}).FirstOrDefaultAsync();
	}

	public async Task<PagedResult<Category_GetAll_Response>> GetAllAsync()
	{
		var categories = await _context.Categories
			.OrderByDescending(i => i.CreatedOn)
			.Select(i => new Category_GetAll_Response
			{
				Id = i.Id,
				Name = i.Name,
				ParentId = i.ParentId,
				ParentName = i.Parent.Name,
				CreatedBy = i.CreatedByUser!.FullName,
				CreatedOn = i.CreatedOn,
				ModifiedBy = i.ModifiedByUser!.FullName,
				ModifiedOn = i.ModifiedOn,
			}).ToListAsync();

		var res = BuildTree(categories, null);

		return PagedResult<Category_GetAll_Response>.SuccessRes(res);
	}

	private List<Category_GetAll_Response> BuildTree(List<Category_GetAll_Response> categories, int? parentId)
	{
		return categories
			.Where(i => i.ParentId == parentId)
			.Select(i => new Category_GetAll_Response
			{
				Id = i.Id,
				Name = i.Name,
				Children = BuildTree(categories, i.Id)
			}).ToList();
	}
}

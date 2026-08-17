using Application.Features.CategoryFeature;
using Application.IRepositories.Common;
using Domain.Commons;
using Domain.Entities;

namespace Application.IRepositories;

public interface ICategoryRepository : IGenericRepository<Category, int>
{
	Task<bool> HasChildren(int id);
	Task<PagedResult<Category_GetAll_Response>> GetAllAsync();
	Task<GetIdTitle<int>?> GetCategoryById(int id);
}
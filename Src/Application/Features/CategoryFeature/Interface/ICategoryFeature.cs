using Application.Features.CategoryFeature;
using Domain.Commons;

namespace Application.Features;

public interface ICategoryFeature
{
	Task<Result<bool>> AddAsync(Category_Add_Request request, int userId);
	Task<Result<bool>> UpdateAsync(int id, Category_Update_Request request, int userId);
	Task<Result<bool>> DeleteAsync(int id, int userId);
	Task<PagedResult<Category_GetAll_Response>> GetAll();
	Task<Result<GetIdTitle<int>>> GetCategoryById(int id);
}

namespace Application.Features.CategoryFeature;

public partial class CategoryFeature
{
	public async Task<PagedResult<Category_GetAll_Response>> GetAll()
	{
		var res = await _repository.GetAllAsync();
		if (!res.Success)
			return PagedResult<Category_GetAll_Response>.FailRes();

		return res;
	}
}

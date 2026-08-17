using Domain.Commons;

namespace Application.Features.CategoryFeature;

public partial class CategoryFeature
{
	public async Task<Result<GetIdTitle<int>>> GetCategoryById(int id)
	{
		var category = await _repository.GetCategoryById(id);
		if (category is null)
			return Result<GetIdTitle<int>>.FailRes(ErrorMessages.NotFound);

		return Result<GetIdTitle<int>>.SuccessRes(category);
	}
}

namespace Application.Features.CategoryFeature;

public partial class CategoryFeature
{
	public async Task<Result<bool>> UpdateAsync(int id, Category_Update_Request request, int userId)
	{
		var category = await _repository.GetByIdAsync(id);
		if (category is null)
			return Result<bool>.FailRes(ErrorMessages.NotFound);

		category.Name = request.Name.Trim();

		var res = await _repository.UpdateAsync(category, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotUpdated);

		return Result<bool>.SuccessRes(true);
	}
}

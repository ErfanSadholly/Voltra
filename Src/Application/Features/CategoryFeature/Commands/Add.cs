using Domain.Entities;

namespace Application.Features.CategoryFeature;

public partial class CategoryFeature
{
	public async Task<Result<bool>> AddAsync(Category_Add_Request request, int userId)
	{
		var category = new Category()
		{
			Name = request.Name.Trim(),
			ParentId = request.ParentId,
		};

		var res = await _repository.AddAsync(category, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotAdded);

		return Result<bool>.SuccessRes(true);
	}
}

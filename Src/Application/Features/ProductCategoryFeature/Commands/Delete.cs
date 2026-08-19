namespace Application.Features.ProductCategoryFeature;

public partial class ProductCategoryFeature
{
	public async Task<Result<bool>> DeleteAsync(int id, int userId)
	{
		var productCategory = await _repository.GetByIdAsync(id);
		if (productCategory is null)
			return Result<bool>.FailRes(ErrorMessages.NotFound);

		var res = await _repository.DeleteAsync(productCategory, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotDeleted);

		return Result<bool>.SuccessRes(true);
	}
}

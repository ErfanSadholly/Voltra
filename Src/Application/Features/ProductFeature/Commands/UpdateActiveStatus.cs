namespace Application.Features;

public partial class ProductFeature
{
	public async Task<Result<bool>> UpdateActiveStatus(bool isActive, int productId, int userId)
	{
		var product = await _repository.GetByIdAsync(productId);
		if (product == null)
			return Result<bool>.FailRes(ErrorMessages.NotFound);

		product.IsActive = isActive;

		var res = await _repository.UpdateAsync(product, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotUpdated);

		return Result<bool>.SuccessRes(true);
	}
}

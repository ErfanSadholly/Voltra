namespace Application.Features;

public partial class ProductPriceFeature
{
	public async Task<Result<bool>> UpdateAsync(int id, ProductPrice_Update_Request request, int userId)
	{
		var productPrice = await _repository.GetByIdAsync(id);
		if (productPrice is null)
			return Result<bool>.FailRes(ErrorMessages.NotFound);

		productPrice.Price = request.Price;

		var res = await _repository.UpdateAsync(productPrice, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotUpdated);

		return Result<bool>.SuccessRes(true);
	}
}
namespace Application.Features;

public partial class ProductFeature
{
	public async Task<Result<Product_GetDetails_Response>> GetDetails(int productId)
	{
		var product = await _repository.GetByIdAsync(productId);
		if (product is null)
			return Result<Product_GetDetails_Response>.FailRes(ErrorMessages.ProductNotFound);

		return Result<Product_GetDetails_Response>.SuccessRes(await _repository.GetDetails(productId));
	}
}

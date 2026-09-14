namespace Application.Features;

public partial class ProductIventoryFeature
{
	public async Task<Result<ProductIventory_GetByProductId_Response>> GetByProductId(int productId)
	{
		var product = await _productRepository.GetByIdAsync(productId);
		if (product == null)
			return Result<ProductIventory_GetByProductId_Response>.FailRes(ErrorMessages.ProductNotFound);

		var res = await _repository.GetByProductId(productId);
		return Result<ProductIventory_GetByProductId_Response>.SuccessRes(res);
	}
}

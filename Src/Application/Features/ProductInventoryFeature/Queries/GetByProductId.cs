namespace Application.Features;

public partial class ProductInventoryFeature
{
	public async Task<Result<ProductInventory_GetByProductId_Response>> GetByProductId(int productId)
	{
		var product = await _productRepository.GetByIdAsync(productId);
		if (product == null)
			return Result<ProductInventory_GetByProductId_Response>.FailRes(ErrorMessages.ProductNotFound);

		var res = await _repository.GetByProductId(productId);
		return Result<ProductInventory_GetByProductId_Response>.SuccessRes(res);
	}
}

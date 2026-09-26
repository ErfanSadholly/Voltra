namespace Application.Features.ProductCategoryFeature;

public partial class ProductCategoryFeature
{
	public async Task<Result<List<ProductCategory_GetByProductId_Response>>> GetByProductId(int productId)
	{
		var product = await _productRepository.GetByIdAsync(productId);
		if (product is null)
			return Result<List<ProductCategory_GetByProductId_Response>>.FailRes(ErrorMessages.ProductNotFound);

		return Result<List<ProductCategory_GetByProductId_Response>>.SuccessRes(await _repository.GetByProductId(productId));
	}
}

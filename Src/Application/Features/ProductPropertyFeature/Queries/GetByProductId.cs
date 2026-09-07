namespace Application.Features;

public partial class ProductPropertyFeature
{
	public async Task<Result<List<ProductProperty_GetByProductId_Response>>> GetByProductId(int productId)
	{
		var product = await _productRepository.GetByIdAsync(productId);
		if (product == null)
			return Result<List<ProductProperty_GetByProductId_Response>>.FailRes(ErrorMessages.NotFound);

		var res = await _repository.GetByProductId(productId);

		return Result<List<ProductProperty_GetByProductId_Response>>.SuccessRes(res);
	}
}

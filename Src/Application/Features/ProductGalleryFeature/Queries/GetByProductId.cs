namespace Application.Features;

public partial class ProductGalleryFeature
{
	public async Task<Result<List<ProductGallery_GetById_Response>>> GetByProductId(int productId)
	{
		var product = await _productRepository.GetByIdAsync(productId);
		if (product == null)
			return Result<List<ProductGallery_GetById_Response>>.FailRes(ErrorMessages.NotFound);

		var productGallery = await _repository.GetByProductId(productId);
		return Result<List<ProductGallery_GetById_Response>>.SuccessRes(productGallery);
	}
}

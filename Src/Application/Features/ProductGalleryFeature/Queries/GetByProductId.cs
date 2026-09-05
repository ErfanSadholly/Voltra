namespace Application.Features;

public partial class ProductGalleryFeature
{
	public async Task<Result<List<ProductGallery_GetById_Response>>> GetByProductId(int productId)
	{
		var productGallery = await _repository.GetByProductId(productId);
		return Result<List<ProductGallery_GetById_Response>>.SuccessRes(productGallery);
	}
}

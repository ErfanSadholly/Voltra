namespace Application.Features;

public interface IProductGalleryFeature
{
	Task<Result<bool>> AddAsync(ProductGallery_Add_Request request, int userId);
	Task<Result<bool>> UpdateAsync(int id, ProductGallery_Update_Request request, int userId);
	Task<Result<bool>> DeleteAsync(int id, int userId);
	Task<Result<List<ProductGallery_GetById_Response>>> GetByProductId(int productId);
}

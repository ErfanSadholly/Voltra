namespace Application.Features;

public partial class ProductGalleryFeature
{
	public async Task<Result<bool>> UpdateAsync(int id, ProductGallery_Update_Request request, int userId)
	{
		var gallery = await _repository.GetByIdAsync(id);
		if (gallery is null)
			return Result<bool>.FailRes(ErrorMessages.NotFound);

		gallery.Order = request.Order;

		var res = await _repository.UpdateAsync(gallery, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotUpdated);

		return Result<bool>.SuccessRes(true);
	}
}

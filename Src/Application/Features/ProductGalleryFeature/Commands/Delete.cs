namespace Application.Features;

public partial class ProductGalleryFeature
{
	public async Task<Result<bool>> DeleteAsync(int id, int userId)
	{
		var gallery = await _repository.GetByIdAsync(id);
		if (gallery is null)
			return Result<bool>.FailRes(ErrorMessages.NotFound);

		var res = await _repository.DeleteAsync(gallery, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotDeleted);

		return Result<bool>.SuccessRes(true);
	}
}

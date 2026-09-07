using Domain.Entities;

namespace Application.Features;

public partial class ProductGalleryFeature
{
	public async Task<Result<bool>> AddAsync(ProductGallery_Add_Request request, int userId)
	{
		var product = await _productRepository.GetByIdAsync(request.ProductId);
		if (product is null)
			return Result<bool>.FailRes(ErrorMessages.ProductNotFound);

		var file = await _fileUploadRepository.GetByIdAsync(request.FileId);
		if (file is null)
			return Result<bool>.FailRes(ErrorMessages.NotFound);

		var gallery = new ProductGallery
		{
			FileId = request.FileId,
			ProductId = request.ProductId,
			Order = request.Order,
		};

		var res = await _repository.AddAsync(gallery, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotAdded);

		return Result<bool>.SuccessRes(true);
	}
}

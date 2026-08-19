using Domain.Entities;

namespace Application.Features.ProductCategoryFeature;

public partial class ProductCategoryFeature
{
	public async Task<Result<bool>> AddAsync(ProductCategory_Add_Request request, int userId)
	{
		var product = await _productRepository.GetByIdAsync(request.ProductId);
		if (product is null)
			return Result<bool>.FailRes("محصول یافت نشد");

		var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
		if (category is null)
			return Result<bool>.FailRes("دسته بندی یافت نشد");

		var existProductInCategory = await _repository.ExistProductInCategory(request.ProductId, request.CategoryId);
		if (existProductInCategory)
			return Result<bool>.FailRes("این محصول از قبل در این دسته بندی قرار دارد");

		var entity = new ProductCategory
		{
			ProductId = request.ProductId,
			CategoryId = request.CategoryId,
		};

		var res = await _repository.AddAsync(entity, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotAdded);

		return Result<bool>.SuccessRes(true);
	}
}

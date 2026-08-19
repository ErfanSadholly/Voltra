namespace Application.Features.CategoryFeature;

public partial class CategoryFeature
{
	public async Task<Result<bool>> DeleteAsync(int id, int userId)
	{
		var category = await _repository.GetByIdAsync(id);
		if (category is null)
			return Result<bool>.FailRes(ErrorMessages.NotFound);

		var hasChild = await _repository.HasChildren(id);
		if (hasChild)
			return Result<bool>.FailRes("اجازه حذف ندارید ابتدا باید زیر شاخه هارا حذف کنید");

		var hasProduct = await _productCategoryRepository.HasProducts(id);
		if (hasProduct)
			return Result<bool>.FailRes("از قبل محصولاتی در این دسته بندی وجود دارد");

		var res = await _repository.DeleteAsync(category, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotDeleted);

		return Result<bool>.SuccessRes(true);
	}
}

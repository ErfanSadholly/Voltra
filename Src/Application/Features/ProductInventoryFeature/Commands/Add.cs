using Domain.Entities;

namespace Application.Features;

public partial class ProductInventoryFeature
{
	public async Task<Result<bool>> AddAsync(ProductInventory_Add_Request request, int userId)
	{
		var product = await _productRepository.GetByIdAsync(request.ProductId);
		if (product == null)
			return Result<bool>.FailRes(ErrorMessages.ProductNotFound);

		var isExistIvemtory = await _repository.IsExistInventoryByProductId(product.Id);
		if (isExistIvemtory)
			return Result<bool>.FailRes(ErrorMessages.IsExistKey);

		var inventory = new ProductInventory
		{
			ProductId = request.ProductId,
			Quantity = request.Quantity,
		};

		var res = await _repository.AddAsync(inventory, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotAdded);

		return Result<bool>.SuccessRes(true);
	}
}

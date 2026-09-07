using Domain.Entities;

namespace Application.Features;

public partial class ProductPriceFeature
{
	public async Task<Result<bool>> AddAsync(ProductPrice_Add_Request request, int userId)
	{
		var product = await _productRepository.GetByIdAsync(request.ProductId);
		if (product == null)
			return Result<bool>.FailRes(ErrorMessages.ProductNotFound);

		var productPrice = new ProductPrice()
		{
			ProductId = request.ProductId,
			Price = request.Price,
		};

		var res = await _repository.AddAsync(productPrice, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotAdded);

		return Result<bool>.SuccessRes(true);
	}
}

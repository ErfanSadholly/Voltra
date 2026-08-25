using Domain.Entities;

namespace Application.Features;

public partial class ProductPriceFeature
{
	public async Task<Result<bool>> AddAsync(ProductPrice_Add_Request request, int userId)
	{
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

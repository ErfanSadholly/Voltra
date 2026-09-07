using Domain.Entities;

namespace Application.Features;

public partial class ProductPropertyFeature
{
	public async Task<Result<bool>> AddAsync(ProductProperty_Add_Request request, int userId)
	{
		var product = await _productRepository.GetByIdAsync(request.ProductId);
		if (product is null)
			return Result<bool>.FailRes(ErrorMessages.NotFound);

		var property = new ProductProperty
		{
			ProductId = request.ProductId,
			Key = request.Key,
			Value = request.Value,
		};

		var res = await _repository.AddAsync(property, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotAdded);

		return Result<bool>.SuccessRes(true);
	}
}

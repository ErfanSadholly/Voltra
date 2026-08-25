namespace Application.Features;

public partial class ProductPriceFeature
{
	public async Task<PagedResult<ProductPrice_GetAll_Response>> GetAll(ProductPrice_GetAll_Request request)
	{
		var res = await _repository.GetAllAsync(request);
		if (!res.Success)
			return PagedResult<ProductPrice_GetAll_Response>.FailRes();

		return res;
	}
}

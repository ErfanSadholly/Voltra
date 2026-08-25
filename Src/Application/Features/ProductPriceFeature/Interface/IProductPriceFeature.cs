namespace Application.Features;

public interface IProductPriceFeature
{
	Task<Result<bool>> AddAsync(ProductPrice_Add_Request request, int userId);
	Task<Result<bool>> UpdateAsync(int id, ProductPrice_Update_Request request, int userId);
	Task<PagedResult<ProductPrice_GetAll_Response>> GetAll(ProductPrice_GetAll_Request request);
}

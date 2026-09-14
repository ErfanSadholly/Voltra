namespace Application.Features;

public interface IProductIventoryFeature
{
	Task<Result<bool>> AddAsync(ProductIventory_Add_Request request, int userId);
	Task<Result<bool>> UpdateAsync(int id, ProductIventory_Update_Request request, int userId);
	Task<Result<ProductIventory_GetByProductId_Response>> GetByProductId(int productId);
}

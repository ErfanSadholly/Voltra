namespace Application.Features;

public interface IProductInventoryFeature
{
	Task<Result<bool>> AddAsync(ProductInventory_Add_Request request, int userId);
	Task<Result<bool>> UpdateAsync(int id, ProductInventory_Update_Request request, int userId);
	Task<Result<ProductInventory_GetByProductId_Response>> GetByProductId(int productId);
}

namespace Application.Features;

public interface IProductPropertyFeature
{
	Task<Result<bool>> AddAsync(ProductProperty_Add_Request request, int userId);
	Task<Result<bool>> UpdateAsync(int id, ProductProperty_Update_Request request, int userId);
	Task<Result<bool>> DeleteAsync(int id, int userId);
	Task<Result<List<ProductProperty_GetByProductId_Response>>> GetByProductId(int productId);
}

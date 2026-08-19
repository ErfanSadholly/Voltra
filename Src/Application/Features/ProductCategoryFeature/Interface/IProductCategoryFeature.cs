namespace Application.Features.ProductCategoryFeature;

public interface IProductCategoryFeature
{
	Task<Result<bool>> AddAsync(ProductCategory_Add_Request request, int userId);
	Task<Result<bool>> DeleteAsync(int id, int userId);
}

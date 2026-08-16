namespace Application.Features;

public interface IProductFeature
{
    Task<Result<bool>> Add(Product_Add_Request request, int userId);
    Task<Result<bool>> Update(int id, Product_Update_Request request, int userId);
    Task<Result<bool>> Delete(int id, int userId);
    Task<Result<Product_GetById_Response>> GetProductById(int id);
    Task<PagedResult<Product_GetAll_Response>> GetAll(Product_GetAll_Request request);
}

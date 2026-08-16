namespace Application.Features;

public interface IBrandFeature
{
    Task<Result<bool>> AddAsync(Brand_Add_Request request, int userId);
    Task<Result<bool>> UpdateAsync(int id, Brand_Update_Request request, int userId);
    Task<Result<bool>> DeleteAsync(int id, int userId);
    Task<PagedResult<Brand_GetAll_Response>> GetAll(Brand_GetAll_Request request);
    Task<Result<Brand_GetById_Response>> GetBrandById(int id);
}

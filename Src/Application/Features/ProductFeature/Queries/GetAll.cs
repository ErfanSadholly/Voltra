namespace Application.Features;

public partial class ProductFeature
{
    public async Task<PagedResult<Product_GetAll_Response>> GetAll(Product_GetAll_Request request)
    {
        var res = await _repository.GetAllAsync(request);
        if (!res.Success)
            return PagedResult<Product_GetAll_Response>.FailRes();

        return res;
    }
}

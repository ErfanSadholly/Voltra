namespace Application.Features;

public partial class BrandFeature
{
    public async Task<PagedResult<Brand_GetAll_Response>> GetAll(Brand_GetAll_Request request)
    {
        var res = await _repository.GetAllAsync(request);
        if (!res.Success)
            return PagedResult<Brand_GetAll_Response>.FailRes();

        return res;
    }
}

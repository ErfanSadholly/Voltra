namespace Application.Features;

public partial class BrandFeature
{
    public async Task<Result<Brand_GetById_Response>> GetBrandById(int id)
    {
        var brand = await _repository.GetBrandById(id);
        if (brand is null)
            return Result<Brand_GetById_Response>.FailRes(ErrorMessages.NotFound);

        return Result<Brand_GetById_Response>.SuccessRes(brand);
    }
}

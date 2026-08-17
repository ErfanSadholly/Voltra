namespace Application.Features;

public partial class BrandFeature
{
    public async Task<Result<bool>> UpdateAsync(int id, Brand_Update_Request request, int userId)
    {
        var brand = await _repository.GetByIdAsync(id);
        if (brand is null)
            return Result<bool>.FailRes(ErrorMessages.NotFound);

        brand.Name = request.Name.Trim();
        brand.LogoUrl = request.LogoUrl;

        var res = await _repository.UpdateAsync(brand, userId);
        if (!res)
            return Result<bool>.FailRes(ErrorMessages.NotUpdated);

        return Result<bool>.SuccessRes(true);
    }
}

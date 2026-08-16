namespace Application.Features;

public partial class BrandFeature
{
    public async Task<Result<bool>> DeleteAsync(int id, int userId)
    {
        var brand = await _repository.GetByIdAsync(id);
        if (brand is null)
            return Result<bool>.FailRes(ErrorMessages.NotFound);

        var res = await _repository.DeleteAsync(brand, userId);
        if (!res)
            return Result<bool>.FailRes(ErrorMessages.NotDeleted);

        return Result<bool>.SuccessRes(true);
    }
}


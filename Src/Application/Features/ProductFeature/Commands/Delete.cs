namespace Application.Features;

public partial class ProductFeature
{
    public async Task<Result<bool>> Delete(int id, int userId)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product is null)
            return Result<bool>.FailRes(ErrorMessages.NotFound);

        var res = await _repository.DeleteAsync(product, userId);
        if (!res)
            return Result<bool>.FailRes(ErrorMessages.NotDeleted);

        return Result<bool>.SuccessRes(true);
    }
}

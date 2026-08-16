namespace Application.Features;

public partial class ProductFeature
{
    public async Task<Result<bool>> Update(int id, Product_Update_Request request, int userId)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product is null)
            return Result<bool>.FailRes(ErrorMessages.NotFound);

        product.Name = request.Name;
        product.Description = request.Description;
        product.BrandId = request.BrandId;
        product.IsActive = request.IsActive;

        var res = await _repository.UpdateAsync(product, userId);
        if (!res)
            return Result<bool>.FailRes(ErrorMessages.NotUpdated);

        return Result<bool>.SuccessRes(true);
    }
}

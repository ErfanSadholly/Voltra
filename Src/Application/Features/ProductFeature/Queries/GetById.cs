namespace Application.Features;

public partial class ProductFeature
{
    public async Task<Result<Product_GetById_Response>> GetProductById(int id)
    {
        var product = await _repository.GetProductById(id);
        if (product is null)
            return Result<Product_GetById_Response>.FailRes(ErrorMessages.NotFound);

        return Result<Product_GetById_Response>.SuccessRes(product);
    }
}

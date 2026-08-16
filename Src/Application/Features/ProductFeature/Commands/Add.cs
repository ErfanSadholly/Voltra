using Domain.Entities;

namespace Application.Features;

public partial class ProductFeature
{
    public async Task<Result<bool>> Add(Product_Add_Request request, int userId)
    {
        var product = new Product()
        {
            Name = request.Name,
            Description = request.Description,
            BrandId = request.BrandId,
            IsActive = request.IsActive,
        };

        var res = await _repository.AddAsync(product, userId);
        if (!res)
            return Result<bool>.FailRes(ErrorMessages.NotAdded);

        return Result<bool>.SuccessRes(true);
    }
}
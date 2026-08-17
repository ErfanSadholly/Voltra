using Domain.Entities;

namespace Application.Features;

public partial class BrandFeature
{
    public async Task<Result<bool>> AddAsync(Brand_Add_Request request, int userId)
    {
        var brand = new Brand()
        {
            Name = request.Name.Trim(),
            LogoUrl = request.LogoUrl,
        };

        var res = await _repository.AddAsync(brand, userId);
        if (!res)
            return Result<bool>.FailRes(ErrorMessages.NotAdded);

        return Result<bool>.SuccessRes(true);
    }
}

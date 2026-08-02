using Domain;

namespace Application.Features;

public partial class RoleFeature
{
    public async Task<Result<bool>> Add(Role_Add_Request request)
    {
        var roleExist = await _roleManager.RoleExistsAsync(request.RoleName);
        if (roleExist)
            return Result<bool>.FailRes(ErrorMessages.IsExistRole);

        var role = new Role()
        {
            Name = request.RoleName.Trim(),
            Description = request.Description,
        };

        var res = await _roleManager.CreateAsync(role);
        if (!res.Succeeded)
            return Result<bool>.FailRes(ErrorMessages.IsExistRole);

        return Result<bool>.SuccessRes(true);
    }
}
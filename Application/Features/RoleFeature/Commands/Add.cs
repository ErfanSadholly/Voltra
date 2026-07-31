using Domain;

namespace Application.Features;

public partial class RoleFeature
{
    public async Task<Result<bool>> Add(string roleName)
    {
        var roleExist = await _roleManager.RoleExistsAsync(roleName);
        if (roleExist)
            return Result<bool>.FailRes(ErrorMessages.IsExistRole);

        var role = new Role()
        {
            Name = roleName.Trim(),
        };

        var res = await _roleManager.CreateAsync(role);
        if (!res.Succeeded)
            return Result<bool>.FailRes(ErrorMessages.IsExistRole);

        return Result<bool>.SuccessRes(true);
    }
}
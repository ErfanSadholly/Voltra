namespace Application.Features;

public partial class UserRoleFeature
{
    public async Task<Result<bool>> AddUserToRoleAsync(int id, string roleName)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
            return Result<bool>.FailRes(ErrorMessages.UserNotFound);

        var role = await _roleManager.FindByNameAsync(roleName);
        if (role is null)
            return Result<bool>.FailRes(ErrorMessages.NotFound);

        var userInRoleExist = await  _userManager.IsInRoleAsync(user, role.Name!);
        if (userInRoleExist)
            return Result<bool>.FailRes(ErrorMessages.IsExistUserInRole);

        var res = await _userManager.AddToRoleAsync(user, role.Name!);
        if (!res.Succeeded)
            return Result<bool>.FailRes(res.GetIdentityErrorMessage());

        return Result<bool>.SuccessRes(true);
    }
}

namespace Application.Features;

public partial class UserRoleFeature
{
    public async Task<Result<bool>> RemoveUserFromRole(int id, string roleName)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
            return Result<bool>.FailRes(ErrorMessages.UserNotFound);

        var role = await _roleManager.FindByNameAsync(roleName);
        if (role is null)
            return Result<bool>.FailRes(ErrorMessages.NotFound);

        var userisInRole = await _userManager.IsInRoleAsync(user, role.Name!);
        if (!userisInRole)
            return Result<bool>.FailRes("کاربر در این نقش وجود ندارد");

        var res = await _userManager.RemoveFromRoleAsync(user, role.Name!);
        if (!res.Succeeded)
            return Result<bool>.FailRes(res.GetIdentityErrorMessage());

        return Result<bool>.SuccessRes(true);
    }
}

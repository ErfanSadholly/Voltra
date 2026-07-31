namespace Application.Features;

public partial class RoleFeature
{
    public async Task<Result<bool>> Delete(int roleId)
    {
        var role = await _roleManager.FindByIdAsync(roleId.ToString());
        if (role is null)
            return Result<bool>.FailRes(ErrorMessages.NotFound);

        var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name!);
        if (usersInRole.Any())
            return Result<bool>.FailRes(ErrorMessages.IsExistUserInRole);         

        var res = await _roleManager.DeleteAsync(role);
        if (!res.Succeeded)
            return Result<bool>.FailRes(ErrorMessages.NotDeleted);

        return Result<bool>.SuccessRes(true);
    }
}

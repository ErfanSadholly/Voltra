namespace Application.Features;

public partial class RoleFeature
{
    public async Task<Result<bool>> Update(int roleId, string roleName)
    {
        var role = await _roleManager.FindByIdAsync(roleId.ToString());
        if (role is null)
            return Result<bool>.FailRes(ErrorMessages.NotFound);

        var exitingRole = await _roleManager.FindByNameAsync(roleName);
        if (exitingRole is null || exitingRole.Id == roleId)
        {
            role.Name = roleName.Trim();
        }
        else
        {
            return Result<bool>.FailRes(ErrorMessages.IsExistRole);
        }
         
        var res = await _roleManager.UpdateAsync(role);
        if (!res.Succeeded)
            return Result<bool>.FailRes(ErrorMessages.NotUpdated);

        return Result<bool>.SuccessRes(true);
    }
}

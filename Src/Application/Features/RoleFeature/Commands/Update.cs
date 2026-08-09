namespace Application.Features;

public partial class RoleFeature
{
    public async Task<Result<bool>> Update(int roleId, Role_Update_Request request)
    {
        var role = await _roleManager.FindByIdAsync(roleId.ToString());
        if (role is null)
            return Result<bool>.FailRes(ErrorMessages.NotFound);

        var exitingRole = await _roleManager.FindByNameAsync(request.RoleName);
        if (exitingRole is null || exitingRole.Id == roleId)
        {
            role.Name = request.RoleName.Trim();
            role.Description = request.Description;
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

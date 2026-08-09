namespace Application.Features;

public partial class RoleFeature
{
    public async Task<Result<Role_GetRoleById_Response>> GetRoleById(int id)
    {
        var role = await _roleManager.FindByIdAsync(id.ToString());
        if (role is null)
            return Result<Role_GetRoleById_Response>.FailRes(ErrorMessages.NotFound);

        var res = new Role_GetRoleById_Response()
        {
            Id = role.Id,
            Name = role.Name!,
            Description = role.Description,
        };

        return Result<Role_GetRoleById_Response>.SuccessRes(res);
    }
}

namespace Application.Features;

public interface IRoleFeature
{
    Task<Result<bool>> Add(string roleName);
    Task<Result<bool>> Update(int roleId, string roleName);
    Task<Result<bool>> Delete(int roleId);
    Task<Result<Role_GetRoleById_Response>> GetRoleById(int id);
}

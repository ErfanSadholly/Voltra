namespace Application.Features;

public interface IUserRoleFeature
{
    Task<Result<bool>> AddUserToRoleAsync(int id, string roleName);
    Task<Result<bool>> RemoveUserFromRole(int id, string roleName);
}

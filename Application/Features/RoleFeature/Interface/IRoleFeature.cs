namespace Application.Features;

public interface IRoleFeature
{
    Task<Result<bool>> Add(Role_Add_Request request);
    Task<Result<bool>> Update(int roleId, Role_Update_Request request);
    Task<Result<bool>> Delete(int roleId);
    Task<Result<Role_GetRoleById_Response>> GetRoleById(int id);
}

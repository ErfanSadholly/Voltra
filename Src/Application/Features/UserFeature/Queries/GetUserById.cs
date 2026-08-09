namespace Application.Features;

public partial class UserFeature
{
    public async Task<Result<User_GetUserById_Response>> GetUserById(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
            return Result<User_GetUserById_Response>.FailRes(ErrorMessages.UserNotFound);

        var res = new User_GetUserById_Response
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber!,
            Email = user.Email,
            Roles = await _userManager.GetRolesAsync(user),
        };

        return Result<User_GetUserById_Response>.SuccessRes(res);
    }
}

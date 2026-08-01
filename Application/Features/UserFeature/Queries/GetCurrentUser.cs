using System.Security.Claims;

namespace Application.Features;

public partial class UserFeature
{
    public async Task<Result<User_GetCurrentUser_Response>> GetCurrentUser(int userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user is null)
            return Result<User_GetCurrentUser_Response>.FailRes(ErrorMessages.UserNotFound);

        var getCurrentUser = new User_GetCurrentUser_Response
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            Roles = await _userManager.GetRolesAsync(user)
        };

        return Result<User_GetCurrentUser_Response>.SuccessRes(getCurrentUser);
    }
}

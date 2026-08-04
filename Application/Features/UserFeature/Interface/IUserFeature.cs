namespace Application.Features;

public interface IUserFeature
{
    Task<Result<bool>> UpdateProfile(User_UpdateProfile_Request request, int userId);
    Task<Result<User_GetCurrentUser_Response>> GetCurrentUser(int userId);
    Task<Result<bool>> ChangePassword(int userId, User_ChangePassword_Request request);
    Task<Result<bool>> ChangePhoneNumber(User_ChangePhoneNumber_Request request, int userId);
    Task<Result<bool>> ResetPassword(int id, User_ResetPassword_Request request);
    Task<Result<User_GetUserById_Response>> GetUserById(int id);
}
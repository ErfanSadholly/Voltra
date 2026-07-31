namespace Application.Features;

public interface IUserFeature
{
    Task<Result<bool>> Register(User_Register_Request request);
    Task<Result<string>> Login(User_Login_Request request);
    Task<Result<bool>> UpdateProfile(User_UpdateProfile_Request request, int userId);
    Task<Result<User_GetCurrentUser_Response>> GetCurrentUser();
    Task<Result<bool>> ChangePassword(int userId, User_ChangePassword_Request request);
    Task<Result<bool>> ChangePhoneNumber(User_ChangePhoneNumber_Request request, int userId);
}
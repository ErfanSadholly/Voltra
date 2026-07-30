namespace Application.Features;

public interface IUserFeature
{
    Task<Result<bool>> Register(User_Register_Request request);
    Task<Result<string>> Login(User_Login_Request request);
}
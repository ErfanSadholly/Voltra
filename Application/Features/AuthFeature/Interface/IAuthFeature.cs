namespace Application.Features;

public interface IAuthFeature
{
    Task<Result<bool>> Register(Auth_Register_Request request);
    Task<Result<Auth_Login_Response>> Login(Auth_Login_Request request);
    Task<Result<Auth_RefreshToken_Response>> RefreshToken(string token);
}

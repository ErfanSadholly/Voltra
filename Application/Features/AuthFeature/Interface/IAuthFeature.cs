namespace Application.Features;

public interface IAuthFeature
{
    Task<Result<bool>> Register(Auth_Register_Request request);
    Task<Result<string>> Login(Auth_Login_Request request);
}

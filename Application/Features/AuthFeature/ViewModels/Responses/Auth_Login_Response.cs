namespace Application.Features;

public class Auth_Login_Response
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }    
}

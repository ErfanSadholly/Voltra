namespace Application.Features;

public class Auth_Login_Result
{
	public required string AccessToken { get; set; }
	public required string RefreshToken { get; set; }
}

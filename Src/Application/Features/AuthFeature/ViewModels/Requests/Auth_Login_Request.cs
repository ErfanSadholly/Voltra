namespace Application.Features;

public class Auth_Login_Request
{
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
}

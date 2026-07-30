namespace Application.Features;

public class User_Login_Request
{
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
}

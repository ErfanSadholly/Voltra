namespace Application.Features;

public class Auth_Register_Request
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }    
}

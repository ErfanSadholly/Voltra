namespace Application.Features;

public class User_ChangePassword_Request
{
    public required string CurrentPassword { get; set; }
    public required string NewPassword { get; set; }
    public required string ConfirmPassword { get; set; }    
}

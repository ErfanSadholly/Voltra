namespace Application.Features;

public class User_GetCurrentUser_Response
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty; 
    public string? Email { get; set; }
    public IList<string> Roles { get; set; } = new List<string>();
}

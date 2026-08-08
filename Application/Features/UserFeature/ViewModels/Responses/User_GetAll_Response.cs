namespace Application.Features;

public class User_GetAll_Response
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime CreatedOn { get; set; } 
}

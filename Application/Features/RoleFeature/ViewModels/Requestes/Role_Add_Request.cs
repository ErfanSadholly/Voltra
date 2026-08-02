namespace Application.Features;

public class Role_Add_Request
{
    public required string RoleName { get; set; }
    public string? Description { get; set; }
}

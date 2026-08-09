namespace Application.Features;

public class Role_GetRoleById_Response
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }    
}
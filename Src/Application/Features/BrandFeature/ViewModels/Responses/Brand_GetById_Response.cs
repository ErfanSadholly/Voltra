namespace Application.Features;

public class Brand_GetById_Response
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LogoUrl { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
}

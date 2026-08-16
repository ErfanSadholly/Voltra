namespace Application.Features;

public class Product_GetById_Response
{
    public int Id { get; set; } 
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int? BrandId { get; set; }
    public bool IsActive { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }

}
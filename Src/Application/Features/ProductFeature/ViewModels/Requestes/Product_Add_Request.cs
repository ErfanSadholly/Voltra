namespace Application.Features;

public class Product_Add_Request
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int? BrandId { get; set; }
    public bool IsActive { get; set; }
}

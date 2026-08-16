namespace Application.Features;

public class Product_GetAll_Request : PagerViewModel
{
    public string? Name { get; set; }
    public string? BrandName { get; set; }  
    public int? BrandId { get; set; }
}

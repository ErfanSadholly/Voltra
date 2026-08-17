namespace Application.Features.CategoryFeature;

public class Category_Add_Request
{
	public required string Name { get; set; }
	public int? ParentId { get; set; }	
}

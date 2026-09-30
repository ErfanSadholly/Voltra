namespace Application.Features;

public class Product_GetAll_Request : PagerViewModel
{
	public string? Name { get; set; }
	public int? BrandId { get; set; }
	public int? CreatedBy { get; set; }
	public DateTime? CreatedOn { get; set; }
	public int? ModifiedBy { get; set; }
	public DateTime? ModifiedOn { get; set; }
}

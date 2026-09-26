namespace Application.Features;

public class ProductCategory_GetByProductId_Response
{
	public int Id { get; set; }
	public int CategoryId { get; set; }
	public string? CategoryName { get; set; }
	public string? CreatedBy { get; set; }
	public DateTime CreatedOn { get; set; }
	public string? ModifiedBy { get; set; }
	public DateTime? ModifiedOn { get; set; }
}

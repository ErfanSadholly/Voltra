namespace Application.Features;

public class ProductPrice_GetAll_Response
{
	public int Id { get; set; }
	public int ProductId { get; set; }
	public string? ProductName { get; set; }
	public decimal Price { get; set; }
	public string? CreatedBy { get; set; }
	public DateTime CreatedOn { get; set; }
	public string? ModifiedBy { get; set; }
	public DateTime? ModifiedOn { get; set; }
}

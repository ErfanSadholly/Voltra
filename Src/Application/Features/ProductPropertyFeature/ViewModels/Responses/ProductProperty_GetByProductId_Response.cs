namespace Application.Features;

public class ProductProperty_GetByProductId_Response
{
	public int Id { get; set; }
	public int ProductId { get; set; }
	public string? ProductName { get; set; }
	public string? Key { get; set; }
	public string? Value { get; set; }
	public string? CreatedBy { get; set; }
	public DateTime CreatedOn { get; set; }
	public string? ModifiedBy { get; set; }
	public DateTime? ModifiedOn { get; set; }
}

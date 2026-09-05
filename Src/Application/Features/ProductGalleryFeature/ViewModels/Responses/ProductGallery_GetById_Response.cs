namespace Application.Features;

public class ProductGallery_GetById_Response
{
	public int ProductId { get; set; }
	public int FileId { get; set; }
	public int Order { get; set; }
	public string? CreatedBy { get; set; }
	public DateTime CreatedOn { get; set; }
	public string? ModifiedBy { get; set; }
	public DateTime? ModifiedOn { get; set; }	
}

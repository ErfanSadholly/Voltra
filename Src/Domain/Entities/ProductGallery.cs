namespace Domain.Entities;

public class ProductGallery : BaseEntity<int>
{
	public int ProductId { get; set; }
	public int FileId { get; set; }
	public int Order { get; set; }
	public Product Product { get; set; } = null!;
	public FileUpload File { get; set; } = null!;
}

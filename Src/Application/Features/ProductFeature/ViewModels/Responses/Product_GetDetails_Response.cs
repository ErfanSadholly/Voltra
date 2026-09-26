namespace Application.Features;

public class Product_GetDetails_Response
{
	public Product_GetAll_Response? Products { get; set; }
	public List<ProductGallery_GetById_Response> ProductGalleries { get; set; } = new List<ProductGallery_GetById_Response>();
	public ProductInventory_GetByProductId_Response ProductInventory { get; set; } = null!;
	public List<ProductPrice_GetAll_Response> ProductPrice { get; set; } = new List<ProductPrice_GetAll_Response>();
	public List<ProductProperty_GetByProductId_Response> ProductProperties { get; set; } = new List<ProductProperty_GetByProductId_Response>();
	public List<ProductCategory_GetByProductId_Response> ProductCategories { get; set; } = new List<ProductCategory_GetByProductId_Response>();
}

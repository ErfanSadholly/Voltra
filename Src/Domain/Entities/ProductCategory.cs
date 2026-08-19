namespace Domain.Entities;

public class ProductCategory : BaseEntity<int>
{
	public int ProductId { get; set; }	
	public int CategoryId { get; set; }
}

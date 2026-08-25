namespace Domain.Entities;

public class ProductPrice : BaseEntity<int>
{
	public int ProductId { get; set; }
	public decimal Price { get; set; }
	public Product Product { get; set; } = null!;
}
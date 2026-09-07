namespace Application.Features;

public class ProductProperty_Add_Request
{
	public int ProductId { get; set; }
	public required string Key { get; set; }
	public required string Value { get; set; }
}
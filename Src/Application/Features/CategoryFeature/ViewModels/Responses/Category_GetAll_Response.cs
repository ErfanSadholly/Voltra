using Domain.Entities;

namespace Application.Features.CategoryFeature;

public class Category_GetAll_Response
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public int? ParentId { get; set; }
	public string? ParentName { get; set; }
	public string? CreatedBy { get; set; }
	public DateTime CreatedOn { get; set; }
	public string? ModifiedBy { get; set; }
	public DateTime? ModifiedOn { get; set; }
	public IList<Category_GetAll_Response> Children { get; set; } = new List<Category_GetAll_Response>();
}
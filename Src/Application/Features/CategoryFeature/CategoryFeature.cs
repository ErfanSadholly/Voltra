using Application.IRepositories;

namespace Application.Features.CategoryFeature;

public partial class CategoryFeature : ICategoryFeature
{
	private readonly ICategoryRepository _repository;

	public CategoryFeature(ICategoryRepository repository)
	{
		_repository = repository;
	}
}

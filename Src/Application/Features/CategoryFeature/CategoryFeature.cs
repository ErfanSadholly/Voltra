using Application.IRepositories;

namespace Application.Features.CategoryFeature;

public partial class CategoryFeature : ICategoryFeature
{
	private readonly ICategoryRepository _repository;
	private readonly IProductCategoryRepository _productCategoryRepository;

	public CategoryFeature(ICategoryRepository repository, IProductCategoryRepository productCategoryRepository)
	{
		_repository = repository;
		_productCategoryRepository = productCategoryRepository;
	}
}

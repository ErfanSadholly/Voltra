using Application.IRepositories;

namespace Application.Features.ProductCategoryFeature;

public partial class ProductCategoryFeature : IProductCategoryFeature
{
	private readonly IProductCategoryRepository _repository;
	private readonly IProductRepository _productRepository;
	private readonly ICategoryRepository _categoryRepository;

	public ProductCategoryFeature(IProductCategoryRepository repository, IProductRepository productRepository, ICategoryRepository categoryRepository)
	{
		_repository = repository;
		_productRepository = productRepository;
		_categoryRepository = categoryRepository;
	}
}

using Application.IRepositories;

namespace Application.Features;

public partial class ProductIventoryFeature : IProductIventoryFeature
{
	private readonly IProductIventoryRepository _repository;
	private readonly IProductRepository _productRepository;
	public ProductIventoryFeature(IProductIventoryRepository repository, IProductRepository productRepository)
	{
		_repository = repository;
		_productRepository = productRepository;
	}
}

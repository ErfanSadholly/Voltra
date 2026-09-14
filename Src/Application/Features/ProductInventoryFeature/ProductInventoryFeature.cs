using Application.IRepositories;

namespace Application.Features;

public partial class ProductInventoryFeature : IProductInventoryFeature
{
	private readonly IProductInventoryRepository _repository;
	private readonly IProductRepository _productRepository;
	public ProductInventoryFeature(IProductInventoryRepository repository, IProductRepository productRepository)
	{
		_repository = repository;
		_productRepository = productRepository;
	}
}

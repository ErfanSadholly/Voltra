using Application.IRepositories;

namespace Application.Features;

public partial class ProductPriceFeature : IProductPriceFeature
{
	private readonly IProductPriceRepository _repository;
	private readonly IProductRepository _productRepository;

	public ProductPriceFeature(IProductPriceRepository repository, IProductRepository productRepository)
	{
		_repository = repository;
		_productRepository = productRepository;
	}
}

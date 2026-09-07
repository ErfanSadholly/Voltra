using Application.IRepositories;

namespace Application.Features;

public partial class ProductPropertyFeature : IProductPropertyFeature
{
	private readonly IProductPropertyRepository _repository;
	private readonly IProductRepository _productRepository;

	public ProductPropertyFeature(IProductPropertyRepository repository, IProductRepository productRepository)
	{
		_repository = repository;
		_productRepository = productRepository;
	}
}

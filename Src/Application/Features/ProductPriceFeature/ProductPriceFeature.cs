using Application.IRepositories;

namespace Application.Features;

public partial class ProductPriceFeature : IProductPriceFeature
{
	private readonly IProductPriceRepository _repository;

	public ProductPriceFeature(IProductPriceRepository repository)
	{
		_repository = repository;
	}
}

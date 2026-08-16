using Application.IRepositories;

namespace Application.Features;

public partial class ProductFeature : IProductFeature
{
    private readonly IProductRepository _repository;

    public ProductFeature(IProductRepository repository)
    {
        _repository = repository;
    }
}

using Application.IRepositories;

namespace Application.Features;

public partial class BrandFeature : IBrandFeature
{
    private readonly IBrandRepository _repository;

    public BrandFeature(IBrandRepository repository)
    {
        _repository = repository;
    }
}

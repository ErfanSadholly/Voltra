using Application.IRepositories;

namespace Application.Features;

public partial class ProductGalleryFeature : IProductGalleryFeature
{
	private readonly IProductGalleryRepository _repository;
	private readonly IProductRepository _productRepository;
	private readonly IFileUploadRepository _fileUploadRepository;

	public ProductGalleryFeature(IProductGalleryRepository repository, IProductRepository productRepository, IFileUploadRepository fileUploadRepository)
	{
		_repository = repository;
		_productRepository = productRepository;
		_fileUploadRepository = fileUploadRepository;
	}
}

using Application.Features;
using Application.IRepositories.Common;
using Domain.Entities;

namespace Application.IRepositories;

public interface IProductGalleryRepository : IGenericRepository<ProductGallery, int>
{
	Task<List<ProductGallery_GetById_Response>> GetByProductId(int productId);
}

using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductGalleryController : CommonController
	{
		private readonly IProductGalleryFeature _feature;

		public ProductGalleryController(IProductGalleryFeature feature)
		{
			_feature = feature;
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> Add([FromBody] ProductGallery_Add_Request request)
		{
			var res = await _feature.AddAsync(request, base.UserId);
			return Ok(res);
		}

		[HttpPut("[action]/{id}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductGallery_Update_Request request)
		{
			var res = await _feature.UpdateAsync(id, request, base.UserId);
			return Ok(res);
		}

		[HttpDelete("[action]/{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var res = await _feature.DeleteAsync(id, base.UserId);
			return Ok(res);
		}

		[HttpGet("[action]/{productId}")]
		public async Task<IActionResult> GetByProductId([FromRoute] int productId)
		{
			var res = await _feature.GetByProductId(productId);
			return Ok(res);
		}
	}
}
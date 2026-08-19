using Application.Features.ProductCategoryFeature;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductCategoryController : CommonController
	{
		private readonly IProductCategoryFeature _feature;

		public ProductCategoryController(IProductCategoryFeature feature)
		{
			_feature = feature;
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> Add([FromBody] ProductCategory_Add_Request request)
		{
			var res = await _feature.AddAsync(request, base.UserId);
			return Ok(res);
		}

		[HttpDelete("[action]/{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var res = await _feature.DeleteAsync(id, base.UserId);
			return Ok(res);
		}
	}
}
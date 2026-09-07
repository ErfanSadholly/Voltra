using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductPropertyController : CommonController
	{
		private readonly IProductPropertyFeature _feature;

		public ProductPropertyController(IProductPropertyFeature feature)
		{
			_feature = feature;
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> Add([FromBody] ProductProperty_Add_Request request)
		{
			var res = await _feature.AddAsync(request, base.UserId);
			return Ok(res);
		}

		[HttpPut("[action]/{id}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductProperty_Update_Request request)
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
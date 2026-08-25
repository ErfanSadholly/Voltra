using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductPriceController : CommonController
	{
		private readonly IProductPriceFeature _feature;

		public ProductPriceController(IProductPriceFeature feature)
		{
			_feature = feature;
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> Add([FromBody] ProductPrice_Add_Request request)
		{
			var res = await _feature.AddAsync(request, base.UserId);
			return Ok(res);
		}

		[HttpPut("[action]/{id}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductPrice_Update_Request request)
		{
			var res = await _feature.UpdateAsync(id, request, base.UserId);
			return Ok(res);
		}

		[HttpGet("[action]")]
		public async Task<IActionResult> GetAll([FromQuery] ProductPrice_GetAll_Request request)
		{
			var res = await _feature.GetAll(request);
			return Ok(res);
		}
	}
}
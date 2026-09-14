using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductIventoryController : CommonController
	{
		private readonly IProductIventoryFeature _feature;

		public ProductIventoryController(IProductIventoryFeature feature)
		{
			_feature = feature;
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> Add([FromBody] ProductIventory_Add_Request request)
		{
			var res = await _feature.AddAsync(request, base.UserId);
			return Ok(res);
		}

		[HttpPut("[action]/{id}")]
		public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductIventory_Update_Request request)
		{
			var res = await _feature.UpdateAsync(id, request, base.UserId);
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
using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ErrorLogController : CommonController
	{
		private readonly IErrorLogFeature _feature;
		public ErrorLogController(IErrorLogFeature feature)
		{
			_feature = feature;
		}

		[HttpPost("[action]/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var res = await _feature.GetByIdAsync(id);
			return Ok(res);
		}
	}
}

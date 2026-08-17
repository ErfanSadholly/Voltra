using Application.Features;
using Application.Features.CategoryFeature;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CommonController
    {
        private readonly ICategoryFeature _feature;

        public CategoryController(ICategoryFeature feature)
        {
            _feature = feature;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] Category_Add_Request request)
        {
            var res = await _feature.AddAsync(request, base.UserId);
            return Ok(res);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Category_Update_Request request)
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

		[HttpGet("[action]")]
		public async Task<IActionResult> GetAll()
		{
			var res = await _feature.GetAll();
			return Ok(res);
		}

		[HttpGet("[action]/{id}")]
		public async Task<IActionResult> GetCategoryById([FromRoute] int id)
		{
			var res = await _feature.GetCategoryById(id);
			return Ok(res);
		}
	}
}
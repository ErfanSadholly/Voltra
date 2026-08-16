using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : CommonController
    {
        private readonly IBrandFeature _feature;

        public BrandController(IBrandFeature feature)
        {
            _feature = feature;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] Brand_Add_Request request)
        {
            var res = await _feature.AddAsync(request, base.UserId);
            return Ok(res);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Brand_Update_Request request)
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

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var res = await _feature.GetBrandById(id);
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] Brand_GetAll_Request request)
        {
            var res = await _feature.GetAll(request);
            return Ok(res);
        }
    }
}
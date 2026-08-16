using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CommonController
    {
        private readonly IProductFeature _feature;

        public ProductController(IProductFeature feature)
        {
            _feature = feature;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] Product_Add_Request request)
        {
            var res = await _feature.Add(request, base.UserId);
            return Ok(res);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Product_Update_Request request)
        {
            var res = await _feature.Update(id, request, base.UserId);
            return Ok(res);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var res = await _feature.Delete(id, base.UserId);
            return Ok(res);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var res = await _feature.GetProductById(id);
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] Product_GetAll_Request request)
        {
            var res = await _feature.GetAll(request);
            return Ok(res);
        }
    }
}
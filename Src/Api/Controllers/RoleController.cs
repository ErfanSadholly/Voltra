using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : CommonController
    {
        private readonly IRoleFeature _feature;

        public RoleController(IRoleFeature feature)
        {
            _feature = feature;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] Role_Add_Request request)
        {
            var res = await _feature.Add(request);
            return Ok(res);
        }

        [HttpPut("[action]/{roleId}")]
        public async Task<IActionResult> Update([FromRoute] int roleId, [FromBody] Role_Update_Request request)
        {
            var res = await _feature.Update(roleId, request);
            return Ok(res);
        }

        [HttpDelete("[action]/{roleId}")]
        public async Task<IActionResult> Delete([FromRoute] int roleId)
        {
            var res = await _feature.Delete(roleId);
            return Ok(res);
        }

        [HttpGet("[action]/{roleId}")]
        public async Task<IActionResult> GetRoleById([FromRoute] int roleId)
        {
            var res = await _feature.GetRoleById(roleId);
            return Ok(res);
        }
    }
}
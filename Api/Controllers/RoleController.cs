using Application.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Add([FromBody] string roleName)
        {
            var res = await _feature.Add(roleName);
            return Ok(res);
        }

        [HttpPut("[action]/{roleId}")]
        public async Task<IActionResult> Update([FromRoute] int roleId, [FromBody] string roleName)
        {
            var res = await _feature.Update(roleId, roleName);
            return Ok(res);
        }

        [HttpDelete("[action]/{roleId}")]
        public async Task<IActionResult> Delete([FromRoute] int roleId)
        {
            var res = await _feature.Delete(roleId);
            return Ok(res);
        }
    }
}
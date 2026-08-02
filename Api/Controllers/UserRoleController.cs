using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : CommonController
    {
        private readonly IUserRoleFeature _feature;
        public UserRoleController(IUserRoleFeature feature)
        {
            _feature = feature;
        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> AddUserToRoleAsync([FromRoute] int id, [FromBody] string roleName)
        {
            var res = await _feature.AddUserToRoleAsync(id, roleName);
            return Ok(res);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> RemoveUserFromRole([FromRoute] int id, [FromBody] string roleName)
        {
            var res = await _feature.RemoveUserFromRole(id, roleName);
            return Ok(res);
        }
    }
}

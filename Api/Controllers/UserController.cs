using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CommonController
    {
        private readonly IUserFeature _feature;
        public UserController(IUserFeature feature)
        {
            _feature = feature;
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProfile([FromBody] User_UpdateProfile_Request request)
        {
            var res = await _feature.UpdateProfile(request, base.UserId);
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var res = await _feature.GetCurrentUser(base.UserId);
            return Ok(res);
        }

        [HttpPut("[action]/{userId}")]
        public async Task<IActionResult> ChangePassword([FromRoute] int userId, [FromBody] User_ChangePassword_Request request)
        {
            var res = await _feature.ChangePassword(userId, request);
            return Ok(res);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ChangePhoneNumber(User_ChangePhoneNumber_Request request, int userId)
        {
            var res = await _feature.ChangePhoneNumber(request, base.UserId);
            return Ok(res);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> ResetPassword(User_ResetPassword_Request request, int id)
        {
            var res = await _feature.ResetPassword(id, request);
            return Ok(res);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var res = await _feature.GetUserById(id);
            return Ok(res);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] User_GetAll_Request request)
        {
            var res = await _feature.GetAll(request);
            return Ok(res);
        }
    }
}
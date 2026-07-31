using Application.Features;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] User_Register_Request request)
        {
            var res = await _feature.Register(request);
            return Ok(res);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] User_Login_Request request)
        {
            var res = await _feature.Login(request);
            return Ok(res);
        }

        [Authorize]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProfile([FromBody] User_UpdateProfile_Request request)
        {
            var res = await _feature.UpdateProfile(request, base.UserId);
            return Ok(res);
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var res = await _feature.GetCurrentUser();
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
    }
}
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

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(User_Register_Request request)
        {
            var res = await _feature.Register(request);
            return Ok(res);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(User_Login_Request request)
        {
            var res = await _feature.Login(request);
            return Ok(res);
        }
    }
}
using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : CommonController
    {
        private readonly IAuthFeature _feature;
        public AuthController(IAuthFeature authFeature)
        {
            _feature = authFeature;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] Auth_Register_Request request)
        {
            var res = await _feature.Register(request);
            return Ok(res);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] Auth_Login_Request request)
        {
            var res = await _feature.Login(request);
            return Ok(res);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshToken([FromBody] string token)
        {
            var res = await _feature.RefreshToken(token);
            return Ok(res);
        }
    }
}

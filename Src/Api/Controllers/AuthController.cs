using Application.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace BattryShopApi.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : CommonController
	{
		private readonly IAuthFeature _feature;
		private const string RefreshTokenCookie = "refreshToken";

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
			if (!res.Success)
				return Ok(res);

			Response.Cookies.Append(RefreshTokenCookie, res.Data.RefreshToken, new CookieOptions
			{
				HttpOnly = true,
				Secure = true,
				SameSite = SameSiteMode.Strict,
				Expires = DateTime.Now.AddDays(7)
			});

			var response = new Auth_Login_Response
			{
				AccessToken = res.Data.AccessToken
			};

			return Ok(Result<Auth_Login_Response>.SuccessRes(response));
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> RefreshToken([FromBody] string token)
		{
			var res = await _feature.RefreshToken(token);
			return Ok(res);
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> Logout([FromBody] string token)
		{
			var res = await _feature.Logout(token);
			return Ok(res);
		}
	}
}

using Application.IServices;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Services;

public class HttpContextService : IHttpContextService
{
	private readonly IHttpContextAccessor _contextAccessor;

	public HttpContextService(IHttpContextAccessor contextAccessor)
	{
		_contextAccessor = contextAccessor;
	}

	public void DeleteCookie(string key)
	{
		_contextAccessor.HttpContext?.Response.Cookies.Delete(key);
	}

	public string? GetCookie(string key)
	{
		return _contextAccessor.HttpContext?.Request.Cookies[key];
	}

	public int? GetUserId()
	{
		return int.TryParse(_contextAccessor.HttpContext?.User
			.FindFirstValue(ClaimTypes.NameIdentifier), out var userId) ? userId : null;
	}
}

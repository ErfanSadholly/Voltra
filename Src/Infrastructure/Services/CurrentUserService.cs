using Application.IServices;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
	private readonly IHttpContextAccessor _contextAccessor;

	public CurrentUserService(IHttpContextAccessor contextAccessor)
	{
		_contextAccessor = contextAccessor;
	}

	public int? GetUserId()
	{
		return int.TryParse(_contextAccessor.HttpContext?.User
			.FindFirstValue(ClaimTypes.NameIdentifier), out var userId) ? userId : null;
	}
}

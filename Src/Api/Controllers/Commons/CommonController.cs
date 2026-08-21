#if RELEASE
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
public class CommonController : ControllerBase
{
	protected int UserId
	{
		get
		{
			int.TryParse(base.User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);
			if (userId <= 0)
				throw new UnauthorizedAccessException();

			return userId;
		}
	}
}
#endif
#if DEBUG
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class CommonController : ControllerBase
{
    protected int UserId => 1;
}

#endif
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
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
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
    protected string? CurrentToken => "None";
}

#endif
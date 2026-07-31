using Domain;
using Microsoft.AspNetCore.Identity;

namespace Application.Features;

public partial class RoleFeature : IRoleFeature
{
    private readonly RoleManager<Role> _roleManager;
    private readonly UserManager<User> _userManager;
    public RoleFeature(RoleManager<Role> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }
}

using Domain;
using Microsoft.AspNetCore.Identity;

namespace Application.Features;

public partial class UserRoleFeature : IUserRoleFeature
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;


    public UserRoleFeature(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
}

using Application.IRepositories;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace Application.Features;

public partial class UserFeature : IUserFeature
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IUserRepository _repository;
    private readonly IConfiguration _configuration;

    public UserFeature(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IUserRepository repository, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _repository = repository;
        _configuration = configuration;
    }
}
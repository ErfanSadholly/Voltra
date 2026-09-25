using Application.IRepositories;
using Application.IServices;
using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Application.Features;

public partial class AuthFeature : IAuthFeature
{
	private readonly UserManager<User> _userManager;
	private readonly SignInManager<User> _signInManager;
	private readonly IConfiguration _configuration;
	private readonly IValidator<Auth_Register_Request> _registerValidator;
	private readonly IRefreshTokenRepository _repository;
	private readonly ICurrentUserService _currentUserService;
	private readonly IHttpContextAccessor _httpContextAccessor;

	public AuthFeature(UserManager<User> userManager,
		SignInManager<User> signInManager,
		IValidator<Auth_Register_Request> registerValidator,
		IConfiguration configuration,
		IRefreshTokenRepository repository,
		ICurrentUserService currentUserService,
		IHttpContextAccessor httpContextAccessor)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		_registerValidator = registerValidator;
		_configuration = configuration;
		_repository = repository;
		_currentUserService = currentUserService;
		_httpContextAccessor = httpContextAccessor;
	}
}
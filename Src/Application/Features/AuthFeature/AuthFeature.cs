using Application.IRepositories;
using Application.IServices;
using Domain;
using FluentValidation;
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
	private readonly IHttpContextService _httpContextService;

	public AuthFeature(UserManager<User> userManager,
		SignInManager<User> signInManager,
		IValidator<Auth_Register_Request> registerValidator,
		IConfiguration configuration,
		IRefreshTokenRepository repository,
		IHttpContextService httpContextService)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		_registerValidator = registerValidator;
		_configuration = configuration;	
		_repository = repository;
		_httpContextService = httpContextService;
	}
}
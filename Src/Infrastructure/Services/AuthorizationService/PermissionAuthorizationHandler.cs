using Application.IServices;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Services.AuthorizationService;

public sealed class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
	private readonly AppPermissionRepository _permissionRepository;
	private readonly AppRolePermissionRepository _rolePermissionRepository;
	private readonly ICurrentUserService _currentUser;
	private readonly IHostEnvironment _environment;

	public PermissionAuthorizationHandler(AppPermissionRepository permissionRepository, AppRolePermissionRepository rolePermissionRepository, ICurrentUserService currentUser, IHostEnvironment environment)
	{
		_permissionRepository = permissionRepository;
		_rolePermissionRepository = rolePermissionRepository;
		_currentUser = currentUser;
		_environment = environment;
	}

	protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
	{
		if (_environment.IsDevelopment())
		{
			context.Succeed(requirement);
			return;
		}

		if (context.User.Identity?.IsAuthenticated != true)
			return;

		if (context.Resource is not HttpContext httpContext)
			return;

		var action = httpContext.GetEndpoint()?.Metadata.GetMetadata<ControllerActionDescriptor>();
		if (action is null)
			return;

		var permission = await _permissionRepository.GetPermissionAsync(action.ControllerName, action.ActionName);
		if (permission is null)
			return;

		var userId = _currentUser.GetUserId();
		if (userId.HasValue == false)
			return;

		var hasPermission = await _rolePermissionRepository.UserHasPermission(permission.Id, userId.Value);
		if (hasPermission)
			context.Succeed(requirement);
	}
}

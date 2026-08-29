using Application.IServices;
using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Infrastructure.Services.AuthorizationService;

public class PermissionSyncService : IPermissionSyncService
{
	private readonly IActionDescriptorCollectionProvider _actionDescriptorCollection;
	private readonly AppControllerRepository _controllerRepository;
	private readonly MainDbContext _context;

	public PermissionSyncService(IActionDescriptorCollectionProvider actionDescriptorCollection,
		AppControllerRepository controllerRepository,
		MainDbContext context)
	{
		_actionDescriptorCollection = actionDescriptorCollection;
		_controllerRepository = controllerRepository;
		_context = context;
	}

	private static bool IsApiController(ControllerActionDescriptor descriptor)
	{
		return typeof(ControllerBase).IsAssignableFrom(descriptor.ControllerTypeInfo.AsType());
	}

	public async Task SyncAsync()
	{
		var actions = _actionDescriptorCollection.ActionDescriptors.Items
			.OfType<ControllerActionDescriptor>();

		var controllers = await _controllerRepository.GetControllersWithActions();

		foreach (var action in actions)
		{
			if (IsApiController(action) == false)
				continue;

			var controller = controllers.FirstOrDefault(i => i.Name == action.ControllerName);
			if (controller is null)
			{
				controller = new AppController
				{
					Name = action.ControllerName,
				};

				controllers.Add(controller);
				_context.Add(controller);
			}

			var appAction = controller.Actions.FirstOrDefault(i => i.Name == action.ActionName);
			if (appAction is null)
			{
				appAction = new AppAction
				{
					Name = action.ActionName,
				};

				controller.Actions.Add(appAction);
			}

			if (appAction.Permission is null)
			{
				appAction.Permission = new AppPermission
				{
					Name = $"{controller.Name}.{appAction.Name}"
				};
			}
		}
		await _context.SaveChangesAsync();
	}
}
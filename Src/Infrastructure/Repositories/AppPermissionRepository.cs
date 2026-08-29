using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AppPermissionRepository
{
	private readonly MainDbContext _context;
	public AppPermissionRepository(MainDbContext Context, MainDbContext context)
	{
		_context = context;
	}

	public Task<AppPermission?> GetPermissionAsync(string controllerName, string actionName)
	{
		return _context.AppPermissions
			.FirstOrDefaultAsync(i => i.Action.Name == actionName
			&& i.Action.Controller.Name == controllerName);
	}
}

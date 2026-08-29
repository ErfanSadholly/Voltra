using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AppRolePermissionRepository
{
	private readonly MainDbContext _context;

	public AppRolePermissionRepository(MainDbContext context)
	{
		_context = context;
	}

	public Task<bool> UserHasPermission(int permissionId, int userId)
	{
		return _context.AppRolePermissions
			.AnyAsync(i => i.PermissionId == permissionId
			&& _context.UserRoles
			.Any(x => x.UserId == userId && x.RoleId == i.RoleId));
	}
}

using Application.IServices;

namespace BattryShopApi.Extensions;

public static class PermissionSyncExtensions
{
	public static async Task SyncAuthorizationAsync(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();
		var syncService = scope.ServiceProvider.GetRequiredService<IPermissionSyncService>();
		await syncService.SyncAsync();
	}
}
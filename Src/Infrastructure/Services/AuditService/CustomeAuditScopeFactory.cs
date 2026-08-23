using Application.IServices;
using Audit.Core;

namespace Infrastructure.Services.AuditService;

public class CustomeAuditScopeFactory : AuditScopeFactory
{
	private readonly ICurrentUserService _currentUser;

	public CustomeAuditScopeFactory(ICurrentUserService currentUser)
	{
		_currentUser = currentUser;
	}

	public override void OnScopeCreated(AuditScope auditScope)
	{
		auditScope.SetCustomField("UserId", _currentUser.GetUserId());
	}
}

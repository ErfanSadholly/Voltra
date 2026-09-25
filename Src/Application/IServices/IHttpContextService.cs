namespace Application.IServices;

public interface IHttpContextService
{
	int? GetUserId();
	string GetCookie(string key);
	void DeleteCookie(string key);
}

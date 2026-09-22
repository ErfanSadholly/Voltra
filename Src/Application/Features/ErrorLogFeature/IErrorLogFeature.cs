namespace Application.Features;

public interface IErrorLogFeature
{
	Task<Result<ErrorLog_GetById_Response>> GetByIdAsync(int id);
}

using Application.IRepositories;

namespace Application.Features;

public class ErrorLogFeature : IErrorLogFeature
{
	private readonly IErrorLogRepository _repository;
	public ErrorLogFeature(IErrorLogRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<ErrorLog_GetById_Response>> GetByIdAsync(int id)
	{
		return Result<ErrorLog_GetById_Response>.SuccessRes(await _repository.GetByIdAsync(id));
	}
}

using Domain.Commons;

namespace Application.Features;

public partial class UserFeature
{
	public async Task<Result<List<GetIdTitle<int>>>> GetIdTitle()
	{
		return Result<List<GetIdTitle<int>>>.SuccessRes(await _repository.GetIdTitle());
	}
}

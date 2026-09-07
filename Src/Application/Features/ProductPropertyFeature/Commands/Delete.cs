namespace Application.Features;

public partial class ProductPropertyFeature
{
	public async Task<Result<bool>> DeleteAsync(int id, int userId)
	{
		var proprty = await _repository.GetByIdAsync(id);
		if (proprty == null)
			return Result<bool>.FailRes(ErrorMessages.NotFound);

		var res = await _repository.DeleteAsync(proprty, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotDeleted);

		return Result<bool>.SuccessRes(true);
	}
}

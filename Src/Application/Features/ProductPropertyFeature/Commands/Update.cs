namespace Application.Features;

public partial class ProductPropertyFeature
{
	public async Task<Result<bool>> UpdateAsync(int id, ProductProperty_Update_Request request, int userId)
	{
		var property = await _repository.GetByIdAsync(id);
		if (property is null)
			return Result<bool>.FailRes(ErrorMessages.NotFound);

		property.Key = request.Key;
		property.Value = request.Value;

		var res = await _repository.UpdateAsync(property, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotUpdated);

		return Result<bool>.SuccessRes(true);
	}
}
namespace Application.Features;

public partial class ProductIventoryFeature
{
	public async Task<Result<bool>> UpdateAsync(int id, ProductIventory_Update_Request request, int userId)
	{
		var iventory = await _repository.GetByIdAsync(id);
		if (iventory == null)
			return Result<bool>.FailRes(ErrorMessages.NotFound);

		iventory.Quantity = request.Quantity;

		var res = await _repository.UpdateAsync(iventory, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotUpdated);

		return Result<bool>.SuccessRes(true);
	}
}

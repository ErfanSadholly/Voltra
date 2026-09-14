namespace Application.Features;

public partial class ProductInventoryFeature
{
	public async Task<Result<bool>> UpdateAsync(int id, ProductInventory_Update_Request request, int userId)
	{
		var inventory = await _repository.GetByIdAsync(id);
		if (inventory == null)
			return Result<bool>.FailRes(ErrorMessages.NotFound);

		inventory.Quantity = request.Quantity;

		var res = await _repository.UpdateAsync(inventory, userId);
		if (!res)
			return Result<bool>.FailRes(ErrorMessages.NotUpdated);

		return Result<bool>.SuccessRes(true);
	}
}

namespace Application.Features;

public partial class SettingFeature
{
    public async Task<Result<bool>> DeleteAsync(int id, int userId)
    {
        var setting = await _repository.GetByIdAsync(id);
        if (setting is null)
            return Result<bool>.FailRes(ErrorMessages.NotFound);

        var res = await _repository.DeleteAsync(setting, userId);
        if (!res)
            return Result<bool>.FailRes(ErrorMessages.NotDeleted);

        return Result<bool>.SuccessRes(true);
    }
}

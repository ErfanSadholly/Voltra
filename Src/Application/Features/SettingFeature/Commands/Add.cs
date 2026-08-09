using Domain.Entities;

namespace Application.Features;

public partial class SettingFeature
{
    public async Task<Result<bool>> AddAsync(Setting_Add_Request request, int userId)
    {
        var value = request.IsEncrypted ? _dataProtection.Encrypt(request.Value) : request.Value;
        var setting = await _repository.GetSettingIgnoreFiltersByKey(request.Key);
        if (setting is not null)
        {
            if (!setting.IsDeleted)
                return Result<bool>.FailRes(ErrorMessages.IsExistKey);

            setting.IsDeleted = false;
            setting.Key = request.Key;
            setting.Value = value;
            setting.Description = request.Description;
            setting.IsEncrypted = request.IsEncrypted;
            var update = await _repository.UpdateAsync(setting, userId);
            if (!update)
                return Result<bool>.FailRes(ErrorMessages.NotUpdated);

            return Result<bool>.SuccessRes(true);
        }

        var entity = new Setting
        {
            Key = request.Key,
            Value = value,
            Description = request.Description,
            IsEncrypted = request.IsEncrypted,
        };

        var res = await _repository.AddAsync(entity, userId);
        if (!res)
            return Result<bool>.FailRes(ErrorMessages.NotAdded);

        return Result<bool>.SuccessRes(true);
    }
}

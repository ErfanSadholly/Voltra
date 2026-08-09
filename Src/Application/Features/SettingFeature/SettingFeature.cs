using Application.IRepositories;
using Application.IServices;

namespace Application.Features;

public partial class SettingFeature : ISettingFeature
{
    private readonly ISettingRepository _repository;
    private readonly IDataProtectionService _dataProtection;
    public SettingFeature(ISettingRepository settingRepository, IDataProtectionService dataProtection)
    {
        _repository = settingRepository;
        _dataProtection = dataProtection;
    }
}

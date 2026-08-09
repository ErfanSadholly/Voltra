namespace Application.Features;

public interface ISettingFeature
{
    Task<Result<bool>> AddAsync(Setting_Add_Request request, int userId);
    Task<Result<bool>> DeleteAsync(int id, int userId);
}

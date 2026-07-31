namespace Application.Features;

public partial class UserFeature
{
    public async Task<Result<bool>> Logout()
    {
       await _signInManager.SignOutAsync();
        return Result<bool>.SuccessRes(true);
    }
}

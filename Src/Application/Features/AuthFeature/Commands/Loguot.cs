namespace Application.Features;

public partial class AuthFeature
{
    public async Task<Result<bool>> Logout(string token)
    {
        var refreshToken = await _repository.GetRefreshTokenByToken(token);
        if (refreshToken is null)
            return Result<bool>.FailRes(ErrorMessages.TokenNotFound);

        if (!refreshToken.IsActive)
            return Result<bool>.FailRes(ErrorMessages.TokenIsNotValid);

        refreshToken.RevokedAt = DateTime.Now;
        var update = await _repository.UpdateAsync(refreshToken);
        if (!update)
            return Result<bool>.FailRes(ErrorMessages.NotUpdated);

        return Result<bool>.SuccessRes(true);
    }
}

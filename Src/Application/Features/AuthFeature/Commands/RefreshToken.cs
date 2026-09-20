namespace Application.Features;

public partial class AuthFeature
{
    public async Task<Result<Auth_Login_Result>> RefreshToken(string token)
    {
        var refreshToken = await _repository.GetRefreshTokenByToken(token);
        if (refreshToken is null)
            return Result<Auth_Login_Result>.FailRes(ErrorMessages.TokenNotFound);

        if (!refreshToken.IsActive)
            return Result<Auth_Login_Result>.FailRes(ErrorMessages.TokenIsNotValid);

        var accessToken = await Jwt(refreshToken.User);
        if (!accessToken.Success || accessToken.Data is null)
            return Result<Auth_Login_Result>.FailRes(accessToken.Message);

        var createRefreshToken = await CreateRefreshToken(refreshToken.User.Id);
        if (!createRefreshToken.Success || createRefreshToken.Data is null)
            return Result<Auth_Login_Result>.FailRes(createRefreshToken.Message);

        refreshToken.RevokedAt = DateTime.Now;
        var update = await _repository.UpdateAsync(refreshToken);
        if (!update)
            return Result<Auth_Login_Result>.FailRes(ErrorMessages.NotUpdated);

        var res = new Auth_Login_Result()
        {
            AccessToken = accessToken.Data,
            RefreshToken = createRefreshToken.Data,
        };

        return Result<Auth_Login_Result>.SuccessRes(res);
    }
}

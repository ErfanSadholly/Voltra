using Microsoft.EntityFrameworkCore;

namespace Application.Features;

public partial class AuthFeature
{
    public async Task<Result<Auth_Login_Result>> Login(Auth_Login_Request request)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(i => i.PhoneNumber == request.PhoneNumber);
        if (user is null)
            return Result<Auth_Login_Result>.FailRes(ErrorMessages.UserNotFound);

        var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!checkPassword.Succeeded)
            return Result<Auth_Login_Result>.FailRes("رمز عبور اشتباه است");

        var accessToken = await Jwt(user);
        if (!accessToken.Success || accessToken.Data is null)
            return Result<Auth_Login_Result>.FailRes(accessToken.Message);

        var refreshToken = await CreateRefreshToken(user.Id);
        if (!refreshToken.Success || refreshToken.Data is null)
            return Result<Auth_Login_Result>.FailRes(refreshToken.Message);

        var res = new Auth_Login_Result()
        {
            AccessToken = accessToken.Data,
            RefreshToken = refreshToken.Data
        };

        return Result<Auth_Login_Result>.SuccessRes(res);
    }
}
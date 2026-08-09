using Microsoft.EntityFrameworkCore;

namespace Application.Features;

public partial class AuthFeature
{
    public async Task<Result<Auth_Login_Response>> Login(Auth_Login_Request request)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(i => i.PhoneNumber == request.PhoneNumber);
        if (user is null)
            return Result<Auth_Login_Response>.FailRes(ErrorMessages.UserNotFound);

        var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!checkPassword.Succeeded)
            return Result<Auth_Login_Response>.FailRes("رمز عبور اشتباه است");

        var accessToken = await Jwt(user);
        if (!accessToken.Success || accessToken.Data is null)
            return Result<Auth_Login_Response>.FailRes(accessToken.Message);

        var refreshToken = await CreateRefreshToken(user.Id);
        if (!refreshToken.Success || refreshToken.Data is null)
            return Result<Auth_Login_Response>.FailRes(refreshToken.Message);

        var res = new Auth_Login_Response()
        {
            AccessToken = accessToken.Data,
            RefreshToken = refreshToken.Data
        };

        return Result<Auth_Login_Response>.SuccessRes(res);
    }
}
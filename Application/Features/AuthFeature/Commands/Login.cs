using Microsoft.EntityFrameworkCore;

namespace Application.Features;

public partial class AuthFeature
{
    public async Task<Result<string>> Login(Auth_Login_Request request)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(i => i.PhoneNumber == request.PhoneNumber);
        if (user is null)
            return Result<string>.FailRes(ErrorMessages.UserNotFound);

        var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!checkPassword.Succeeded)
            return Result<string>.FailRes("رمز عبور اشتباه است");

        var token = await Jwt(user);
        if (!token.Success || token.Data is null)
            return Result<string>.FailRes(token.Message);

        return Result<string>.SuccessRes(token.Data);
    }
}
namespace Application.Features;

public partial class UserFeature
{
    public async Task<Result<bool>> ResetPassword(int id, User_ResetPassword_Request request)
    {
        var validationResult = await _restPasswordValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return Result<bool>.FailRes(validationResult.GetValidationErrors());

        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
            return Result<bool>.FailRes(ErrorMessages.UserNotFound);

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var res = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);
        if (!res.Succeeded)
            return Result<bool>.FailRes(res.GetIdentityErrorMessage());

        return Result<bool>.SuccessRes(true);
    }
}

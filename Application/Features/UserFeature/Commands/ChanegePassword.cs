namespace Application.Features;

public partial class UserFeature
{
    public async Task<Result<bool>> ChangePassword(int userId, User_ChangePassword_Request request)
    {
        var validationResult = await _changePasswordValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return Result<bool>.FailRes(string.Join(" , ", validationResult.Errors.Select(i => i.ErrorMessage).ToList()));

        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user is null)
            return Result<bool>.FailRes(ErrorMessages.UserNotFound);

        if (request.NewPassword != request.ConfirmPassword)
            return Result<bool>.FailRes(ErrorMessages.PasswordDoNotMatch);

        var res = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (!res.Succeeded)
            return Result<bool>.FailRes(ErrorMessages.PasswordProperty);

        return Result<bool>.SuccessRes(true);
    }
}
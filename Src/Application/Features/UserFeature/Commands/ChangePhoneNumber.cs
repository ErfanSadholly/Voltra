using Microsoft.EntityFrameworkCore;

namespace Application.Features;

public partial class UserFeature
{
    public async Task<Result<bool>> ChangePhoneNumber(User_ChangePhoneNumber_Request request, int userId)
    {
        var validationResult = await _changePhoneNumberValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return Result<bool>.FailRes(validationResult.GetValidationErrors());

        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user is null)
            return Result<bool>.FailRes(ErrorMessages.UserNotFound);

        if (request.PhoneNumber != user.PhoneNumber)
        {
            var isExistPhoneNumber = await _userManager.Users.AnyAsync(i => i.PhoneNumber == request.PhoneNumber);
            if (isExistPhoneNumber)
                return Result<bool>.FailRes(ErrorMessages.IsExistUser);

            var setPhone = await _userManager.SetPhoneNumberAsync(user, request.PhoneNumber);
            if (!setPhone.Succeeded)
                return Result<bool>.FailRes(ErrorMessages.NotUpdated);
        }

        return Result<bool>.SuccessRes(true);
    }
}

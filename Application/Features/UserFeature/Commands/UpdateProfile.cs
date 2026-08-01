namespace Application.Features;

public partial class UserFeature
{
    public async Task<Result<bool>> UpdateProfile(User_UpdateProfile_Request request, int userId)
    {
        var validationResult = await _updateProfileValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return Result<bool>.FailRes(validationResult.GetValidationErrors());

        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user is null)
            return Result<bool>.FailRes(ErrorMessages.UserNotFound);

        bool isChanged = false;
        if (!string.IsNullOrWhiteSpace(request.Email) && request.Email != user.Email)
        {
            var setEmail = await _userManager.SetEmailAsync(user, request.Email);
            if (!setEmail.Succeeded)
                return Result<bool>.FailRes(ErrorMessages.NotUpdated);
            isChanged = true;
        }
        if (!string.IsNullOrWhiteSpace(request.FirstName) && request.FirstName != user.FirstName)
        {
            user.FirstName = request.FirstName;
            isChanged = true;
        }
        if (!string.IsNullOrWhiteSpace(request.LastName) && request.LastName != user.LastName)
        {
            user.LastName = request.LastName;
            isChanged = true;
        }
        if (isChanged)
        {
            user.ModifiedBy = userId;
            user.ModifiedOn = DateTime.Now;

            var res = await _userManager.UpdateAsync(user);
            if (!res.Succeeded)
                return Result<bool>.FailRes(ErrorMessages.NotUpdated);
        }
        return Result<bool>.SuccessRes(true);
    }
}
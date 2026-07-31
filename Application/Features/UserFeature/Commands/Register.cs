using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;

public partial class UserFeature
{
    public async Task<Result<bool>> Register(User_Register_Request request)
    {
        var validationResult = await _registerValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return Result<bool>.FailRes(string.Join(" , ", validationResult.Errors.Select(i => i.ErrorMessage).ToList()));

        if (!string.IsNullOrWhiteSpace(request.Email))
        {
            var emailExist = await _userManager.FindByEmailAsync(request.Email);
            if (emailExist is not null)
                return Result<bool>.FailRes(ErrorMessages.IsExistEmail);
        }

        var isExistPhoneNumber = await _userManager.Users.AnyAsync(i => i.PhoneNumber == request.PhoneNumber);
        if (isExistPhoneNumber)
            return Result<bool>.FailRes(ErrorMessages.IsExistUser);

        if (request.Password != request.ConfirmPassword)
            return Result<bool>.FailRes(ErrorMessages.PasswordDoNotMatch);

        var user = new User
        {
            UserName = request.PhoneNumber,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            CreatedOn = DateTime.Now,
        };

        var res = await _userManager.CreateAsync(user, request.Password);
        if (!res.Succeeded)
            return Result<bool>.FailRes(string.Join(" , ", res.Errors.Select(i => i.Description).ToList()));

        await _userManager.AddToRoleAsync(user, "Customer");

        return Result<bool>.SuccessRes(true);
    }
}
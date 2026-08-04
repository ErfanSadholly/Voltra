using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Identity;


namespace Application.Features;

public partial class UserFeature : IUserFeature
{
    private readonly UserManager<User> _userManager;
    private readonly IValidator<User_UpdateProfile_Request> _updateProfileValidator;
    private readonly IValidator<User_ChangePassword_Request> _changePasswordValidator;
    private readonly IValidator<User_ChangePhoneNumber_Request> _changePhoneNumberValidator;
    private readonly IValidator<User_ResetPassword_Request> _restPasswordValidator;

    public UserFeature(UserManager<User> userManager,
        IValidator<User_UpdateProfile_Request> updateProfilevalidator,
        IValidator<User_ChangePassword_Request> changePasswordValidator,
        IValidator<User_ChangePhoneNumber_Request> changePhoneNumberValidator,
        IValidator<User_ResetPassword_Request> restPasswordValidator)
    {
        _userManager = userManager;
        _updateProfileValidator = updateProfilevalidator;
        _changePasswordValidator = changePasswordValidator;
        _changePhoneNumberValidator = changePhoneNumberValidator;
        _restPasswordValidator = restPasswordValidator;
    }
}
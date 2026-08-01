using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace Application.Features;

public partial class UserFeature : IUserFeature
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly IValidator<User_Register_Request> _registerValidator;
    private readonly IValidator<User_UpdateProfile_Request> _updateProfileValidator;
    private readonly IValidator<User_ChangePassword_Request> _changePasswordValidator;
    private readonly IValidator<User_ChangePhoneNumber_Request> _changePhoneNumberValidator;
    private readonly IValidator<User_ResetPassword_Request> _restPasswordValidator;

    public UserFeature(UserManager<User> userManager,
        SignInManager<User> signInManager,
        IConfiguration configuration,
        IValidator<User_Register_Request> validator,
        IValidator<User_UpdateProfile_Request> updateProfilevalidator,
        IValidator<User_ChangePassword_Request> changePasswordValidator,
        IValidator<User_ChangePhoneNumber_Request> changePhoneNumberValidator,
        IValidator<User_ResetPassword_Request> restPasswordValidator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _registerValidator = validator;
        _updateProfileValidator = updateProfilevalidator;
        _changePasswordValidator = changePasswordValidator;
        _changePhoneNumberValidator = changePhoneNumberValidator;
        _restPasswordValidator = restPasswordValidator;
    }
}
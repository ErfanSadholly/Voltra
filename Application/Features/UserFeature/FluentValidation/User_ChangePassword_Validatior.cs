using Application.Features;
using Application.Validation.Commons;
using FluentValidation;

public class User_ChangePassword_Validatior : AbstractValidator<User_ChangePassword_Request>
{
    public User_ChangePassword_Validatior()
    {
        RuleFor(x => x.NewPassword).ValidPassword();
    }
}
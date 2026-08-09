using Application.Features;
using FluentValidation;

public class User_ChangePassword_Validatior : AbstractValidator<User_ChangePassword_Request>
{
    public User_ChangePassword_Validatior()
    {
        RuleFor(x => x.NewPassword).ValidPassword();
    }
}
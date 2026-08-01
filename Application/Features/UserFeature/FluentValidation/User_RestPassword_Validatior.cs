using Application.Features;
using FluentValidation;

public class User_RestPassword_Validatior : AbstractValidator<User_ResetPassword_Request>
{
    public User_RestPassword_Validatior()
    {
        RuleFor(x => x.NewPassword).ValidPassword();
    }
}
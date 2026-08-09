using Application.Features;
using FluentValidation;

public class User_UpdateProfile_Validatior : AbstractValidator<User_UpdateProfile_Request>
{
    public User_UpdateProfile_Validatior()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrWhiteSpace(x.Email))
            .WithMessage("فرمت ایمیل صحیح نیست.");
    }
}
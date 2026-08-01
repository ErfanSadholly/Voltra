using Application.Features;
using FluentValidation;

public class User_Register_Validator : AbstractValidator<User_Register_Request>
{
    public User_Register_Validator()
    {
        RuleFor(x => x.PhoneNumber).ValidPhoneNumber();

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrWhiteSpace(x.Email))
            .WithMessage("فرمت ایمیل صحیح نیست.");

        RuleFor(x => x.Password).ValidPassword();
    }
}
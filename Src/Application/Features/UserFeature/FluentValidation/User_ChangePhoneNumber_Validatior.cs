using Application.Features;
using FluentValidation;

public class User_ChangePhoneNumber_Validatior : AbstractValidator<User_ChangePhoneNumber_Request>
{
    public User_ChangePhoneNumber_Validatior()
    {
        RuleFor(x => x.PhoneNumber).ValidPhoneNumber();
    }
}
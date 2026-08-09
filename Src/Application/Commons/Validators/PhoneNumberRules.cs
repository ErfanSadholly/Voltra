using FluentValidation;

namespace Application.Commons;

public static class PhoneNumberRules
{
    public static IRuleBuilderOptions<T, string> ValidPhoneNumber<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Matches(@"^09\d{9}$")
            .WithMessage("شماره موبایل باید با 09 شروع شود و دقیقاً 11 رقم باشد.");
    }
}
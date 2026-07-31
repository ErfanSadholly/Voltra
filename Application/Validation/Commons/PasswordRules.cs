using FluentValidation;

namespace Application.Validation.Commons;

public static class PasswordRules
{
    public static IRuleBuilderOptions<T, string> ValidPassword<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .MinimumLength(8)
            .WithMessage("رمز عبور باید حداقل ۸ کاراکتر باشد.")
            .Matches(@"\d")
            .WithMessage("رمز عبور باید حداقل شامل یک رقم باشد.");
    }
}
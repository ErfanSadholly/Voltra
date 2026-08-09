using FluentValidation.Results;

namespace Application.Commons;

public static class ValidationErrors
{
    public static string GetValidationErrors(this ValidationResult validationResult)
    {
        return string.Join(" , ", validationResult.Errors.Select(i => $"{i.ErrorCode}: {i.ErrorMessage}"));
    }
}

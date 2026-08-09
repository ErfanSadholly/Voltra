using Microsoft.AspNetCore.Identity;

namespace Application.Commons;

public static class IdentityExtentions
{
    public static string GetIdentityErrorMessage(this IdentityResult identityResult)
    {
        return string.Join(" , ", identityResult.Errors.Select(i => $"{i.Code}: {i.Description}"));
    }
}

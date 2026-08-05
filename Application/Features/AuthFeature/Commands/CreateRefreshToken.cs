using Domain;
using Domain.Entities;
using System.Security.Cryptography;

namespace Application.Features;

public partial class AuthFeature
{
    private string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }

    public async Task<Result<string>> CreateRefreshToken(User user)
    {
        var refreshToken = new RefreshToken()
        {
            UserId = user.Id,
            Token = GenerateRefreshToken(),
            CreatedAt = DateTime.Now,
            ExpiresAt = DateTime.Now.AddDays(7),
            RevokedAt = null,
        };

        var res = await _repository.AddAsync(refreshToken);
        if (res == false)
            return Result<string>.FailRes(ErrorMessages.NotAdded);

        return Result<string>.SuccessRes(refreshToken.Token);
    }
}

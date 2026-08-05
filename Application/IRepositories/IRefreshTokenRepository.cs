using Domain.Entities;

namespace Application.IRepositories;

public interface IRefreshTokenRepository
{
    Task<bool> AddAsync(RefreshToken refreshToken);
    Task<bool> UpdateAsync(RefreshToken refreshToken);
    Task<RefreshToken?> GetRefreshTokenByToken(string token);
}

using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly MainDbContext _context;

    public RefreshTokenRepository(MainDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<bool> AddAsync(RefreshToken refreshToken)
    {
        _context.RefreshTokens.Add(refreshToken);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(RefreshToken refreshToken)
    {
        _context.RefreshTokens.Update(refreshToken);
        await _context.SaveChangesAsync();
        return true;
    }

    public Task<RefreshToken?> GetRefreshTokenByToken(string token)
    {
        return _context.RefreshTokens
            .Include(i => i.User)
            .FirstOrDefaultAsync(i => i.Token == token);
    }
}

using Application.Features;
using Application.IRepositories;
using Infrastructure.Common;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MainDbContext _context;

    public UserRepository(MainDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<User_GetAll_Response>> GetAll(User_GetAll_Request request)
    {
        var query = _context.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.FirstName))
            query = query.Where(i => i.FirstName.Contains(request.FirstName));

        if (!string.IsNullOrWhiteSpace(request.LastName))
            query = query.Where(i => i.LastName.Contains(request.LastName));

        if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            query = query.Where(i => i.PhoneNumber.Contains(request.PhoneNumber));

        if (!string.IsNullOrWhiteSpace(request.Email))
            query = query.Where(i => i.Email.Contains(request.Email));

        if (request.CreatedFrom.HasValue)
            query = query.Where(i => i.CreatedOn >= request.CreatedFrom.Value.WithMinTime());

        if (request.CreatedTo.HasValue)
            query = query.Where(i => i.CreatedOn <= request.CreatedTo.Value.WithMaxTime());

        var count = await query.CountAsync();

        query = query.OrderByDescending(i => i.CreatedOn);

        query = query.UsePagination(request);

        var res = await query.Select(i => new User_GetAll_Response
        {
            Id = i.Id,
            FullName = i.FullName,
            PhoneNumber = i.PhoneNumber,
            Email = i.Email,
            CreatedOn = i.CreatedOn,
        }).ToListAsync();

        return PagedResult<User_GetAll_Response>.SuccessRes(res, count);
    }
}

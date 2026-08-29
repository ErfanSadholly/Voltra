using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AppControllerRepository
{
	private readonly MainDbContext _context;

	public AppControllerRepository(MainDbContext context)
	{
		_context = context;
	}

	public Task<List<AppController>> GetControllersWithActions()
	{
		return _context.AppControllers
			.Include(i => i.Actions)
			.ThenInclude(i => i.Permission)
			.ToListAsync();
	}
}

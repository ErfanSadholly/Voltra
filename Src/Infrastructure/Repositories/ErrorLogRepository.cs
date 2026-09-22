using Application.Features;
using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ErrorLogRepository(MainDbContext _context) : IErrorLogRepository
{
	public async Task<long> AddAsync(ErrorLog entity, int? userId)
	{
		entity.UserId = userId;
		entity.CreatedOn = DateTime.Now;
		_context.Add(entity);
		await _context.SaveChangesAsync();
		return entity.Id;
	}

	public Task<ErrorLog_GetById_Response?> GetByIdAsync(int id)
	{
		return _context.ErrorLogs
			.Where(i => i.Id == id)
			.Select(i => new ErrorLog_GetById_Response
			{
				Type = i.Type,
				Message = i.Message,
				RequestMethod = i.RequestMethod,
				StackTrace = i.StackTrace,
				InnerException = i.InnerException,
				UrlPath = i.UrlPath,
				Queries = i.Queries,
				UserId = i.UserId,
				Ip = i.Ip,
				CreatedOn = i.CreatedOn,
			}).FirstOrDefaultAsync();
	}
}

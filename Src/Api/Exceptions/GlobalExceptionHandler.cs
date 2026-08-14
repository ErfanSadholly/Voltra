using Application.IRepositories;
using Domain.Entities;
using Microsoft.AspNetCore.Diagnostics;
using Shared;
using System.Security.Claims;

namespace BattryShopApi.Exceptions;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "this Error Unhandled");

        var getUserIdClaim = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var error = new ErrorLog()
        {
            Type = exception.GetType().FullName ?? exception.GetType().Name,
            Message = exception.Message,
            RequestMethod = httpContext.Request.Method,
            StackTrace = exception.StackTrace ?? string.Empty,
            InnerException = exception.InnerException?.ToString(),
            UrlPath = httpContext.Request.Path,
            Queries = httpContext.Request.QueryString.HasValue ? httpContext.Request.QueryString.Value : null,
            UserId = int.TryParse(getUserIdClaim, out var userId) ? userId : null,
            Ip = httpContext.Connection.RemoteIpAddress?.ToString(),
        };

        long? errorId = null;
        try
        {
            await using var scope = _scopeFactory.CreateAsyncScope();
            var repository = scope.ServiceProvider.GetRequiredService<IErrorLogRepository>();
            errorId = await repository.AddAsync(error, error.UserId);
        }
        catch (Exception logException)
        {
            _logger.LogError(logException, "Faild To Save ErrorLog");
        }
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        httpContext.Response.ContentType = "application/json";

        var message = errorId.HasValue
            ? $"خطای غیرمنتظره ای رخ داد! کد خطا : {errorId}"
            : "خطای غیرمنتطره ای رخ داد";
        var res = Result<long>.FailRes(message);
        await httpContext.Response.WriteAsJsonAsync(res, cancellationToken);

        return true;
    }
}

using Application.Commons;

namespace Infrastructure.Common;

public static class Pageination
{
    public static IQueryable<TEntity> UsePageination<TEntity, TRequest>(this IQueryable<TEntity> query, TRequest request)
        where TEntity : class
        where TRequest : PagerViewModel
    {
        if (request.PageNo > 0)
            request.PageNo = 0;

        if (request.PageSize > 0)
            request.PageSize = 0;

        if (request.PageNo != 0 && request.PageSize != 0)
            query = query.Skip((request.PageNo - 1) * request.PageSize).Take(request.PageSize);

        return query;
    }
}

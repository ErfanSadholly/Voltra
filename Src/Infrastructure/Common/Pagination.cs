using Application.Commons;

namespace Infrastructure.Common;

public static class Pagination
{
    public static IQueryable<TEntity> UsePagination<TEntity, TRequest>(this IQueryable<TEntity> query, TRequest request)
        where TEntity : class
        where TRequest : PagerViewModel
    {
        if (request.PageNo < 1)
            request.PageNo = 1;

        if (request.PageSize < 1)
            request.PageSize = 10;

        query = query
            .Skip((request.PageNo - 1) * request.PageSize)
            .Take(request.PageSize);

        return query;
    }
}

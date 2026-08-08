namespace Shared;

public class PagedResult<T> : GeneralResponse
    where T : class, new()
{
    public long TotalCount { get; set; }
    public List<T> Data { get; set; }

    public static PagedResult<T> SuccessRes(List<T> data, long count)
    {
        return new PagedResult<T>(data, count);
    }

    private PagedResult(List<T> data, long count)
    {
        base.Success = true;
        Data = data;
        TotalCount = count;
        base.Message = "عملیات موفقیت آمیز بود";
    }

    public static PagedResult<T> SuccessRes(List<T> data)
    {
        return new PagedResult<T>(data);
    }

    private PagedResult(List<T> data)
    {
        base.Success = true;
        Data = data;
        base.Message = "عملیات موفقیت آمیز بود";
    }

    public static PagedResult<T> FailRes(string message = "")
    {
        if (string.IsNullOrEmpty(message))
            return new PagedResult<T>("عملیات شکست خورد");

        return new PagedResult<T>(message);
    }

    private PagedResult(string message)
    {
        base.Success = false;
        base.Message = message;
    }
}

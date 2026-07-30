namespace Shared;

public class Result<T>
{
    public string Message { get; set; }
    public bool Success { get; set; }
    public T? Data { get; set; }

    public static Result<T> SuccessRes(T data)
    {
        return new Result<T>(data);
    }

    private Result(T data)
    {
        Success = true;
        Data = data;
        Message = "عملیات موفقیت آمیز بود";
    }

    public static Result<T> FailRes(string message = "")
    {
        if (string.IsNullOrEmpty(message))
            return new Result<T>("عملیات شکست خورد");

        return new Result<T>(message);
    }

    private Result(string message)
    {
        Success = false;
        Message = message;
    }
}
using System.Runtime.CompilerServices;

namespace Shared;

public class Result<T> : GeneralResponse
{
	public T? Data { get; set; }
	public string? Code { get; set; }

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

	public static Result<T> FailRes(string message = "", [CallerArgumentExpression("message")] string? expression = null)
	{
		if (string.IsNullOrEmpty(message))
			return new Result<T>("عملیات شکست خورد" , "Failed");

		string? code = null;
		if (expression?.StartsWith("ErrorMessages.") == true)
			code = expression.Split('.').Last();

		return new Result<T>(message , code);
	}

	private Result(string message , string? code)
	{
		Success = false;
		Message = message;
		Code = code;
	}
}
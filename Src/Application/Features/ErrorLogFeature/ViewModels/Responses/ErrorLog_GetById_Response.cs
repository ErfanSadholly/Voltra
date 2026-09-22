using System.ComponentModel.DataAnnotations;

namespace Application.Features;

public class ErrorLog_GetById_Response
{
	public required string Type { get; set; }
	public required string Message { get; set; }
	public required string RequestMethod { get; set; }
	public required string StackTrace { get; set; }
	public string? InnerException { get; set; }
	public required string UrlPath { get; set; }
	public string? Queries { get; set; }
	public int? UserId { get; set; }
	public string? Ip { get; set; }
	public DateTime CreatedOn { get; set; }
}

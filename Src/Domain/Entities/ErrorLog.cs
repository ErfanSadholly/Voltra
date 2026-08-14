using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class ErrorLog : BaseId<long>
{
    [MaxLength(512)]
    public required string Type { get; set; }
    [MaxLength(1024)]
    public required string Message { get; set; }
    [MaxLength(10)]
    public required string RequestMethod { get; set; }
    public required string StackTrace { get; set; }
    public string? InnerException { get; set; }
    [MaxLength(512)]
    public required string UrlPath { get; set; }
    [MaxLength(2048)]
    public string? Queries { get; set; }
    public int? UserId { get; set; }
    [MaxLength(45)]
    public string? Ip { get; set; }
    public DateTime CreatedOn { get; set; }
}

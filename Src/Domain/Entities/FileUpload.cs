using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class FileUpload : BaseEntity<int>
{
	[MaxLength(512)]
	public required string FileName { get; set; }
	[MaxLength(512)]
	public required string FileDisplayName { get; set; }
	[MaxLength(128)]
	public required string ContentType { get; set; }	
	public long Size { get; set; }	
}

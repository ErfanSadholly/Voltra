namespace Application.Features;

public class FileUpload_Download_Response
{
	public Stream FileStream { get; set; } = null!;
	public required string ContentType { get; set; }
	public required string FileName { get; set; }
}

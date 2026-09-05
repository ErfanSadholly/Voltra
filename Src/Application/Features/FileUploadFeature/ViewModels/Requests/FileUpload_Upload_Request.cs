using Microsoft.AspNetCore.Http;

namespace Application.Features;

public class FileUpload_Upload_Request
{
	public required IFormFile File { get; set; }
}

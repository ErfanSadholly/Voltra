namespace Application.Features;

public interface IFileUploadFeature
{
	Task<Result<int>> Upload(FileUpload_Upload_Request request, int userId);
	Task<Result<FileUpload_Download_Response>> Download(int fileId);
}

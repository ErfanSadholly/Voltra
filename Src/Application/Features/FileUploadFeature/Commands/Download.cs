namespace Application.Features;

public partial class FileUploadFeature
{
	public async Task<Result<FileUpload_Download_Response>> Download(int fileId)
	{
		var file = await _repository.GetByIdAsync(fileId);
		if (file is null)
			return Result<FileUpload_Download_Response>.FailRes(ErrorMessages.NotFound);

		var downloadPath = await _settingRepository.GetValueByKey("DownloadFilePath");
		if (string.IsNullOrWhiteSpace(downloadPath))
			return Result<FileUpload_Download_Response>.FailRes("مسیر ذخیره سازی فایل یافت نشد");

		var physicalFilePath = Path.Combine(downloadPath, file.FileName);
		if (!File.Exists(physicalFilePath))
			return Result<FileUpload_Download_Response>.FailRes("فایل فیزیکی یافت نشد");

		var stream = new FileStream(physicalFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);

		var res = new FileUpload_Download_Response
		{
			FileStream = stream,
			ContentType = file.ContentType,
			FileName = file.FileDisplayName,
		};

		return Result<FileUpload_Download_Response>.SuccessRes(res);
	}
}

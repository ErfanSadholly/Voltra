using Domain.Entities;

namespace Application.Features;

public partial class FileUploadFeature
{
	public async Task<Result<int>> Upload(FileUpload_Upload_Request request, int userId)
	{
		if (request.File == null || request.File.Length == 0)
			return Result<int>.FailRes("فایل وجود ندارد");

		var uploadPath = await _settingRepository.GetValueByKey("UploadFilePath");
		if (string.IsNullOrWhiteSpace(uploadPath))
			return Result<int>.FailRes("مسیر ذخیره سازی فایل یافت نشد");

		var displayFileName = Path.GetFileName(request.File.FileName);
		var extension = Path.GetExtension(displayFileName);
		if (!FileUploadConstans.AllowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
			return Result<int>.FailRes("فرمت فایل مجاز نیست");

		var fileName = Guid.NewGuid() + extension;
		var physicalFilePath = Path.Combine(uploadPath, fileName);
		try
		{
			await using (var stream = new FileStream(physicalFilePath, FileMode.CreateNew))
			{
				await request.File.CopyToAsync(stream);
			}

			var fileUpload = new FileUpload()
			{
				FileName = fileName,
				FileDisplayName = displayFileName,
				ContentType = request.File.ContentType,
				Size = request.File.Length
			};

			await _repository.AddAsync(fileUpload, userId);

			return Result<int>.SuccessRes(fileUpload.Id);
		}
		catch
		{
			if (System.IO.File.Exists(physicalFilePath))
				System.IO.File.Delete(physicalFilePath);
			throw;
		}
	}
}

using Application.IRepositories;

namespace Application.Features;

public partial class FileUploadFeature : IFileUploadFeature
{
	private readonly IFileUploadRepository _repository;
	private readonly ISettingRepository _settingRepository;

	public FileUploadFeature(IFileUploadRepository repository, ISettingRepository settingRepository)
	{
		_repository = repository;
		_settingRepository = settingRepository;
	}
}

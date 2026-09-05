using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Commons;

namespace Infrastructure.Repositories;

public class FileUploadRepository : GenericRepository<FileUpload, int> , IFileUploadRepository
{
	public FileUploadRepository(MainDbContext Context) : base(Context)
	{
	}
}

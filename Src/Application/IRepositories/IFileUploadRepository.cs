using Application.IRepositories.Common;
using Domain.Entities;

namespace Application.IRepositories;

public interface IFileUploadRepository : IGenericRepository<FileUpload , int>
{
}

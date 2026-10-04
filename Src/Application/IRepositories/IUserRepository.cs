using Application.Features;
using Domain.Commons;

namespace Application.IRepositories;

public interface IUserRepository
{
    Task<PagedResult<User_GetAll_Response>> GetAll(User_GetAll_Request request);
	Task<List<GetIdTitle<int>>> GetIdTitle();
}

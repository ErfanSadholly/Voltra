namespace Application.Features;

public partial class UserFeature
{
    public async Task<PagedResult<User_GetAll_Response>> GetAll(User_GetAll_Request request)
    {
        var res = await _repository.GetAll(request);
        if (!res.Success)
            return PagedResult<User_GetAll_Response>.FailRes();

        return res;
    }
}
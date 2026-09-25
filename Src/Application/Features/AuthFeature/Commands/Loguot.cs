namespace Application.Features;

public partial class AuthFeature
{
	public async Task<Result<bool>> Logout()
	{
		var userId = _currentUserService.GetUserId();
		if (userId == null)
			return Result<bool>.FailRes(ErrorMessages.UserNotFound);

		var token = _httpContextAccessor.HttpContext?.Request.Cookies["refreshToken"];
		if (string.IsNullOrWhiteSpace(token))
			return Result<bool>.FailRes("رفرش توکن یافت نشد");

		var refreshToken = await _repository.GetRefreshToken(userId.Value, token);
		if (refreshToken is null)
			return Result<bool>.FailRes(ErrorMessages.TokenNotFound);

		if (!refreshToken.IsActive)
			return Result<bool>.FailRes(ErrorMessages.TokenIsNotValid);

		refreshToken.RevokedAt = DateTime.Now;
		var update = await _repository.UpdateAsync(refreshToken);
		if (!update)
			return Result<bool>.FailRes(ErrorMessages.NotUpdated);

		return Result<bool>.SuccessRes(true);
	}
}

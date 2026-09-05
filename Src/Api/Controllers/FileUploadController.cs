using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FileUploadController : CommonController
	{
		private readonly IFileUploadFeature _feature;

		public FileUploadController(IFileUploadFeature feature)
		{
			_feature = feature;
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> Upload([FromForm] FileUpload_Upload_Request request)
		{
			var res = await _feature.Upload(request, base.UserId);
			return Ok(res);
		}

		[HttpGet("[action]/{id}")]
		public async Task<IActionResult> Download([FromRoute] int id)
		{
			var res = await _feature.Download(id);
			if (!res.Success)
				return NotFound(res);

			return File
				(
					res.Data.FileStream,
					res.Data.ContentType,
					res.Data.FileName
				);
		}
	}
}
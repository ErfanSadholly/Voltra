using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace BattryShopApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SettingController : CommonController
{
    private readonly ISettingFeature _feature;

    public SettingController(ISettingFeature feature)
    {
        _feature = feature;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddAsync([FromBody] Setting_Add_Request request)
    {
        var res = await _feature.AddAsync(request, base.UserId);
        return Ok(res);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        var res = await _feature.DeleteAsync(id, base.UserId);
        return Ok(res);
    }
}

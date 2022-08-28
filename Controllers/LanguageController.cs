using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace electronics_shop_mvc_1.Controllers.Api;

[Route("[controller]")]
[ApiController]
public class LanguageController: ControllerBase
{
    private readonly IStringLocalizer<LanguageController> _localizer;

    public LanguageController(IStringLocalizer<LanguageController> localizer)
    {
        _localizer = localizer;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_localizer["Home"]);
    }
}
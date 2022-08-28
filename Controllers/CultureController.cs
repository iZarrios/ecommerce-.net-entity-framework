using System.Drawing.Printing;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace electronics_shop_mvc_1.Controllers;

public class CultureController : Controller
{
    // GET
    public IActionResult SetLanguage(string culture, string returnUrl)
    {
        Console.WriteLine(culture);
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions{Expires = DateTimeOffset.UtcNow.AddYears(1)}
            );
        return LocalRedirect(returnUrl);
    }
}
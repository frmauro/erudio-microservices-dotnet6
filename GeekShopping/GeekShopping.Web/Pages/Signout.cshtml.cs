using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekShopping.Web.Pages;

public class SignoutModel : PageModel
{
    public IActionResult OnGet()
    {
        return SignOut("Cookies", "oidc");
    }
}

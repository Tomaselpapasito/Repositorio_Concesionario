

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Vendedor
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("UsuarioID") == null)
                return RedirectToPage("/Login");

            return Page();
        }
    }
}

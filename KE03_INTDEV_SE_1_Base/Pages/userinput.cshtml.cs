using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class userinputModel : PageModel
    {
        [BindProperty]
        public Customer User { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Hier kun je iets doen met de data, zoals opslaan of tonen
            return Page();
        }
    }
}
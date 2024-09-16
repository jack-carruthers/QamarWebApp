using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QamarWeb.Pages;

public class IndexModel : PageModel
{

    public required List<string> Images { get; set; }

        public void OnGet()
        {
        
        }
}





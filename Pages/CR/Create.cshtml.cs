using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QamarWeb.Models;


namespace QamarWeb.Pages.CR
{
    public class CreateModel : PageModel
    {
        private readonly QamarWeb.Models.QamarModel _context;

        public CreateModel(QamarWeb.Models.QamarModel context)
        {
            _context = context;
        }

        [BindProperty]
        public CommercialRentals CommercialRentals { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CommercialRentals.Add(CommercialRentals);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
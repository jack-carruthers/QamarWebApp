using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QamarWeb.Models;

namespace QamarWeb.Pages_CR
{
    public class DeleteModel : PageModel
    {
        private readonly QamarWeb.Models.QamarModel _context;

        public DeleteModel(QamarWeb.Models.QamarModel context)
        {
            _context = context;
        }

        [BindProperty]
        public CommercialRentals CommercialRentals { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercialrentals = await _context.CommercialRentals.FirstOrDefaultAsync(m => m.CRid == id);

            if (commercialrentals == null)
            {
                return NotFound();
            }
            else
            {
                CommercialRentals = commercialrentals;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercialrentals = await _context.CommercialRentals.FindAsync(id);
            if (commercialrentals != null)
            {
                CommercialRentals = commercialrentals;
                _context.CommercialRentals.Remove(CommercialRentals);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

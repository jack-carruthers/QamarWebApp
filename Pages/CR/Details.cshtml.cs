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
    public class DetailsModel : PageModel
    {
        private readonly QamarWeb.Models.QamarModel _context;

        public DetailsModel(QamarWeb.Models.QamarModel context)
        {
            _context = context;
        }

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
    }
}

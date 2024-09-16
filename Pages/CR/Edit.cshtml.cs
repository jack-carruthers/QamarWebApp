using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QamarWeb.Models;

namespace QamarWeb.Pages_CR
{
    public class EditModel : PageModel
    {
        private readonly QamarWeb.Models.QamarModel _context;

        public EditModel(QamarWeb.Models.QamarModel context)
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

            var commercialrentals =  await _context.CommercialRentals.FirstOrDefaultAsync(m => m.CRid == id);
            if (commercialrentals == null)
            {
                return NotFound();
            }
            CommercialRentals = commercialrentals;
           ViewData["Eid"] = new SelectList(_context.Set<EstateAgent>(), "Eid", "Eid");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CommercialRentals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommercialRentalsExists(CommercialRentals.CRid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CommercialRentalsExists(int id)
        {
            return _context.CommercialRentals.Any(e => e.CRid == id);
        }
    }
}

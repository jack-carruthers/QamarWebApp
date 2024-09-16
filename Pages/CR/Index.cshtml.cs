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
    public class IndexModel : PageModel
    {
        private readonly QamarWeb.Models.QamarModel _context;

        public IndexModel(QamarWeb.Models.QamarModel context)
        {
            _context = context;
        }

        public IList<CommercialRentals> CommercialRentals { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CommercialRentals = await _context.CommercialRentals
                .Include(c => c.EstateAgent).ToListAsync();
        }
    }
}

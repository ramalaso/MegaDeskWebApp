using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWebApp.Data;
using MegaDeskWebApp.Models;

namespace MegaDeskWebApp.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWebApp.Data.MegaDeskWebAppContext _context;

        public IndexModel(MegaDeskWebApp.Data.MegaDeskWebAppContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchCustomer { get; set; }

        public async Task OnGetAsync()
        {
            var deskQuotes = from m in _context.DeskQuote
                         select m;
            if (!string.IsNullOrEmpty(SearchCustomer))
            {
                deskQuotes = deskQuotes.Where(s => s.CustomerName.Contains(SearchCustomer));
            }

            DeskQuote = await deskQuotes.ToListAsync();
        }
    }
}

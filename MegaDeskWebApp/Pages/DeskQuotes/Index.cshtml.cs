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
        public string NameSort { get; set; }
        public string DateSort { get; set; }


        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            var deskQuotes = from m in _context.DeskQuote
                         select m;
            if (!string.IsNullOrEmpty(SearchCustomer))
            {
                deskQuotes = deskQuotes.Where(s => s.CustomerName.Contains(SearchCustomer));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    deskQuotes = deskQuotes.OrderByDescending(s => s.CustomerName);
                    break;
                case "Date":
                    deskQuotes = deskQuotes.OrderBy(s => s.QuoteDate);
                    break;
                case "date_desc":
                    deskQuotes = deskQuotes.OrderByDescending(s => s.QuoteDate);
                    break;
                default:
                    deskQuotes = deskQuotes.OrderBy(s => s.CustomerName);
                    break;
            }

            DeskQuote = await deskQuotes.ToListAsync();
        }
    }
}

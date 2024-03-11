using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using asp_ef_pages.Data;
using asp_ef_pages.Models;

namespace asp_ef_pages.Pages.Classes
{
    public class IndexModel : PageModel
    {
        private readonly asp_ef_pages.Data.SchoolDbContext _context;

        public IndexModel(asp_ef_pages.Data.SchoolDbContext context)
        {
            _context = context;
        }

        public IList<Class> Class { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Class = await _context.Classes.ToListAsync();
        }
    }
}

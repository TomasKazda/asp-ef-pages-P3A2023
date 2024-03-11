using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using asp_ef_pages.Data;
using asp_ef_pages.Models;

namespace asp_ef_pages.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly asp_ef_pages.Data.SchoolDbContext _context;

        public IndexModel(asp_ef_pages.Data.SchoolDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students
                .Include(s => s.Class).ToListAsync();
        }
    }
}

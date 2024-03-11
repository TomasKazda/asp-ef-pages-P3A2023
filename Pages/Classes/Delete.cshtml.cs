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
    public class DeleteModel : PageModel
    {
        private readonly asp_ef_pages.Data.SchoolDbContext _context;

        public DeleteModel(asp_ef_pages.Data.SchoolDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Class Class { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classes = await _context.Classes.FirstOrDefaultAsync(m => m.Id == id);

            if (classes == null)
            {
                return NotFound();
            }
            else
            {
                Class = classes;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classes = await _context.Classes.FindAsync(id);
            if (classes != null)
            {
                Class = classes;
                _context.Classes.Remove(Class);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

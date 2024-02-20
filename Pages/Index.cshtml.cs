using asp_ef_pages.Data;
using asp_ef_pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace asp_ef_pages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly SchoolDbContext _context;

        public IList<Class> ClassesList { get; set; } = new List<Class>();
        public IEnumerable<Class> ClassesEnumerable { get; set; } = new List<Class>();
        public SubjectOnClass SubjectsOnClasses { get; set; } = new SubjectOnClass();

        public IndexModel(ILogger<IndexModel> logger, SchoolDbContext _dbc)
        {
            _logger = logger;
            _context = _dbc;
        }

        public void OnGet()
        {
            //ClassesList = _context.Classes.ToList();

            //ClassesEnumerable = _context.Classes.Include(c => c.Students).AsEnumerable();

            SubjectsOnClasses = _context.SubjectsOnClasses.FirstOrDefault(soc => soc.LinkId == 1);
            //_context.Entry(SubjectsOnClasses).Reference(soc => soc.Class).Load();
        }
    }
}

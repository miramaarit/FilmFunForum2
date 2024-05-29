using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FilmFunForum2.Data;
using FilmFunForum2.Models;

namespace FilmFunForum2.Pages.Admin.ReportAdmin
{
    public class DeleteModel : PageModel
    {
        private readonly FilmFunForum2.Data.FilmFunForum2Context _context;

        public DeleteModel(FilmFunForum2.Data.FilmFunForum2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Report Report { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report.FirstOrDefaultAsync(m => m.Id == id);

            if (report == null)
            {
                return NotFound();
            }
            else
            {
                Report = report;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report.FindAsync(id);
            if (report != null)
            {
                Report = report;
                _context.Report.Remove(Report);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

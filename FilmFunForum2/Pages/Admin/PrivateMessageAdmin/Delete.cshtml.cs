using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FilmFunForum2.Data;
using FilmFunForum2.Models;

namespace FilmFunForum2.Pages.Admin.PrivateMessageAdmin
{
    public class DeleteModel : PageModel
    {
        private readonly FilmFunForum2.Data.FilmFunForum2Context _context;

        public DeleteModel(FilmFunForum2.Data.FilmFunForum2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public PrivateMessage PrivateMessage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privatemessage = await _context.PrivateMessage.FirstOrDefaultAsync(m => m.Id == id);

            if (privatemessage == null)
            {
                return NotFound();
            }
            else
            {
                PrivateMessage = privatemessage;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privatemessage = await _context.PrivateMessage.FindAsync(id);
            if (privatemessage != null)
            {
                PrivateMessage = privatemessage;
                _context.PrivateMessage.Remove(PrivateMessage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

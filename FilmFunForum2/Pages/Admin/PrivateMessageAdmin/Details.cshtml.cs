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
    public class DetailsModel : PageModel
    {
        private readonly FilmFunForum2.Data.FilmFunForum2Context _context;

        public DetailsModel(FilmFunForum2.Data.FilmFunForum2Context context)
        {
            _context = context;
        }

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FilmFunForum2.Data;
using FilmFunForum2.Models;

namespace FilmFunForum2.Pages.Admin.ForumPostAdmin
{
    public class DetailsModel : PageModel
    {
        private readonly FilmFunForum2.Data.FilmFunForum2Context _context;

        public DetailsModel(FilmFunForum2.Data.FilmFunForum2Context context)
        {
            _context = context;
        }

        public ForumPost ForumPost { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumpost = await _context.ForumPost.FirstOrDefaultAsync(m => m.Id == id);
            if (forumpost == null)
            {
                return NotFound();
            }
            else
            {
                ForumPost = forumpost;
            }
            return Page();
        }
    }
}

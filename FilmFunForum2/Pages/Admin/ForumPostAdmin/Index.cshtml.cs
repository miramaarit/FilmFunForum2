using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FilmFunForum2.Data;
using FilmFunForum2.Models;
using Microsoft.AspNetCore.Authorization;

namespace FilmFunForum2.Pages.Admin.ForumPostAdmin
{
	[Authorize(Roles = "Admin")]
	public class IndexModel : PageModel
    {
        private readonly FilmFunForum2.Data.FilmFunForum2Context _context;

        public IndexModel(FilmFunForum2.Data.FilmFunForum2Context context)
        {
            _context = context;
        }

        public IList<ForumPost> ForumPost { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ForumPost = await _context.ForumPost.ToListAsync();
        }
    }
}

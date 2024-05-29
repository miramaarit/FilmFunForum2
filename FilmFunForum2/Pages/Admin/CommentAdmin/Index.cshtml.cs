using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FilmFunForum2.Data;
using FilmFunForum2.Models;

namespace FilmFunForum2.Pages.Admin.CommentAdmin
{
    public class IndexModel : PageModel
    {
        private readonly FilmFunForum2.Data.FilmFunForum2Context _context;

        public IndexModel(FilmFunForum2.Data.FilmFunForum2Context context)
        {
            _context = context;
        }

        public IList<Comment> Comment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Comment = await _context.Comment.ToListAsync();
        }
    }
}

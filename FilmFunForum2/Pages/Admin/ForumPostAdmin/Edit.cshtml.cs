﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmFunForum2.Data;
using FilmFunForum2.Models;

namespace FilmFunForum2.Pages.Admin.ForumPostAdmin
{
    public class EditModel : PageModel
    {
        private readonly FilmFunForum2.Data.FilmFunForum2Context _context;

        public EditModel(FilmFunForum2.Data.FilmFunForum2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ForumPost ForumPost { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumpost =  await _context.ForumPost.FirstOrDefaultAsync(m => m.Id == id);
            if (forumpost == null)
            {
                return NotFound();
            }
            ForumPost = forumpost;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ForumPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumPostExists(ForumPost.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ForumPostExists(int id)
        {
            return _context.ForumPost.Any(e => e.Id == id);
        }
    }
}

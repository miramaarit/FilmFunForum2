using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmFunForum2.Data;
using FilmFunForum2.Models;

namespace FilmFunForum2.Pages.Admin.PrivateMessageAdmin
{
    public class EditModel : PageModel
    {
        private readonly FilmFunForum2.Data.FilmFunForum2Context _context;

        public EditModel(FilmFunForum2.Data.FilmFunForum2Context context)
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

            var privatemessage =  await _context.PrivateMessage.FirstOrDefaultAsync(m => m.Id == id);
            if (privatemessage == null)
            {
                return NotFound();
            }
            PrivateMessage = privatemessage;
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

            _context.Attach(PrivateMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrivateMessageExists(PrivateMessage.Id))
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

        private bool PrivateMessageExists(int id)
        {
            return _context.PrivateMessage.Any(e => e.Id == id);
        }
    }
}

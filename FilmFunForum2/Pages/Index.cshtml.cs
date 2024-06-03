using FilmFunForum2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Claims;
using System.Reflection.Metadata;
using Microsoft.Extensions.Hosting;
using System.Composition;
using Microsoft.AspNetCore.WebUtilities;
using System.Drawing;

namespace FilmFunForum2.Pages
{
	public class IndexModel : PageModel
	{

		private readonly FilmFunForum2.Data.FilmFunForum2Context _context;
		private UserManager<Areas.Identity.Data.FilmFunForum2User> _userManager { get; set; }

		public IndexModel(FilmFunForum2.Data.FilmFunForum2Context context, UserManager<Areas.Identity.Data.FilmFunForum2User> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public Areas.Identity.Data.FilmFunForum2User MyUser { get; set; }

		public List<Models.Category> Categories { get; set; }
		public Models.Category Category { get; set; }
		[BindProperty]
		public Models.ForumPost Post { get; set; }
		public List<Models.ForumPost> Posts { get; set; }

		[BindProperty]
		public IFormFile? UploadedImage { get; set; }


		public string UserImage { get; set; }

		public List<Models.Comment> Comments { get; set; } = new List<Models.Comment>();
		[BindProperty]
		public Models.Comment Comment { get; set; }
		public bool HasFlaggedComments { get; set; }
		public bool IsHomePage { get; set; } = true;
		

		public async Task OnGetAsync()
		{
			HasFlaggedComments = await _context.Comment.AnyAsync(c => c.Flagged);
			MyUser = await _userManager.GetUserAsync(User);
			Comments = await _context.Comment.ToListAsync();
			Categories = await DAL.CategoryManagerAPI.GetAllCategories();
			Posts = await _context.ForumPost.ToListAsync();
			
		}
		public async Task<IActionResult> OnGetShowPostAsync(int showid) //Visa en ForumPost med kommentarer
		{
			IsHomePage = false;
			var currentUser = await _userManager.GetUserAsync(User);

			if (showid != 0)
			{
				if (currentUser != null && await _userManager.IsInRoleAsync(currentUser, "Admin"))
				{
					Post = await _context.ForumPost
					 .Include(p => p.Comments)
					  .FirstOrDefaultAsync(p => p.Id == showid);
				}
				else
				{
					// Hämta inlägget utan flaggade kommentarer
					Post = await _context.ForumPost
						.Include(p => p.Comments)
						.FirstOrDefaultAsync(p => p.Id == showid);

					// Filtrera bort flaggade kommentarer
					if (Post != null)
					{
						Post.Comments = Post.Comments.Where(c => !c.Flagged).ToList();
					}
				}
			}

			if (Post == null)
			{
				return NotFound();
			}

			return Page();

		}


		public async Task<IActionResult> OnPostAsync()
		{

			var image = UploadedImage;
			string fileName = "";

			if (image != null)
			{
				Random rnd = new();
				fileName = rnd.Next(0, 100000).ToString() + image.FileName;
				using (var fileStream = new FileStream("./wwwroot/postImages/" + fileName, FileMode.Create))
				{
					await image.CopyToAsync(fileStream);
				}
			}

			// Hämta den aktuella användaren
			var currentUser = await _userManager.GetUserAsync(User);


			if (currentUser != null)
			{
				// användarens e-postadress som UserId för inlägget
				Post.UserId = currentUser.Email;

				Post.UserImage = currentUser?.UserImage ?? "defaultImage.png";
			}
			Post.Date = DateTime.Now;
			Post.Image = fileName;


			_context.ForumPost.Add(Post);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");

		}
		public async Task<IActionResult> OnPostAddCommentAsync() //Skriva in kommentar
		{
			var image = UploadedImage;
			string fileName = "";

			if (image != null)
			{
				Random rnd = new();
				fileName = rnd.Next(0, 100000).ToString() + image.FileName;
				using (var fileStream = new FileStream("./wwwroot/postImages/" + fileName, FileMode.Create))
				{
					await image.CopyToAsync(fileStream);
				}
			}
			var currentUser = await _userManager.GetUserAsync(User);
			ModelState.Remove("Title");
			ModelState.Remove("Text");
			ModelState.Remove("UserId");

			if (!ModelState.IsValid)
			{
				Post = await _context.ForumPost
			   .Include(p => p.Comments)
			   .FirstOrDefaultAsync(p => p.Id == Comment.ForumPostId);
				return Page();
			}



			Comment.Date = DateTime.Now;
			if (currentUser != null)
			{
				Comment.UserId = currentUser.Email;
				Comment.UserImage = currentUser?.UserImage ?? "defaultImage.png";

			}
			Comment.Image = fileName;
			_context.Comment.Add(Comment);
			await _context.SaveChangesAsync();
			
			return RedirectToPage(new { showid = Comment.ForumPostId, handler="ShowPost" }); 
		}

		public async Task<IActionResult> OnPostDeleteCommentAsync(int commentId, int postId)
		{
			var comment = await _context.Comment.FindAsync(commentId);
			if (comment != null)
			{
                if (!string.IsNullOrEmpty(comment.Image) && System.IO.File.Exists("./wwwroot/postImages/" + comment.Image))
                {
                    System.IO.File.Delete("./wwwroot/postImages/" + comment.Image);
                }
                _context.Comment.Remove(comment);
				await _context.SaveChangesAsync();
			}
			
			return RedirectToPage(new { showid= postId, handler = "ShowPost" });
		}
		public async Task<IActionResult> OnPostDeletePostAsync(int postId)
		{
			var post = await _context.ForumPost
				.Include(p => p.Comments)
				.FirstOrDefaultAsync(p => p.Id == postId);

			if (post != null)
			{
                // Ta bort bilder för alla kommentarer
                foreach (var comment in post.Comments)
                {
                    if (!string.IsNullOrEmpty(comment.Image) && System.IO.File.Exists("./wwwroot/postImages/" + comment.Image))
                    {
                        System.IO.File.Delete("./wwwroot/postImages/" + comment.Image);
                    }
                }

                // Ta bort bilder för inlägget (om det finns bilder för inlägget)
                if (!string.IsNullOrEmpty(post.Image) && System.IO.File.Exists("./wwwroot/postImages/" + post.Image))
                {
                    System.IO.File.Delete("./wwwroot/postImages/" + post.Image);
                }
                _context.Comment.RemoveRange(post.Comments);
				_context.ForumPost.Remove(post);
				await _context.SaveChangesAsync();
			}
			return Page();
		}
	
	}
}










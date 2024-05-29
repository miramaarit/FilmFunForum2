using FilmFunForum2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FilmFunForum2.Models;

namespace FilmFunForum2.Data;

public class FilmFunForum2Context : IdentityDbContext<FilmFunForum2User>
{
    public FilmFunForum2Context(DbContextOptions<FilmFunForum2Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<FilmFunForum2.Models.ForumPost> ForumPost { get; set; } = default!;

public DbSet<FilmFunForum2.Models.Comment> Comment { get; set; } = default!;

public DbSet<FilmFunForum2.Models.Category> Category { get; set; } = default!;

public DbSet<FilmFunForum2.Models.PrivateMessage> PrivateMessage { get; set; } = default!;

public DbSet<FilmFunForum2.Models.Report> Report { get; set; } = default!;
}

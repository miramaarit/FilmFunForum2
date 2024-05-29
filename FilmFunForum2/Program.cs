using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FilmFunForum2.Data;
namespace FilmFunForum2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("FilmFunForum2ContextConnection") ?? throw new InvalidOperationException("Connection string 'FilmFunForum2ContextConnection' not found.");
            
            builder.Services.AddControllers();
            builder.Services.AddDbContext<FilmFunForum2Context>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<Areas.Identity.Data.FilmFunForum2User>(options =>
            options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<FilmFunForum2Context>();

			builder.Services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});
			// Add services to the container.
			builder.Services.AddRazorPages();

            var app = builder.Build();

			app.UseCookiePolicy();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}

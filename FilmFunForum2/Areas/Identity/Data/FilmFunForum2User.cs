using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FilmFunForum2.Areas.Identity.Data;

// Add profile data for application users by adding properties to the FilmFunForum2User class
public class FilmFunForum2User : IdentityUser
{
    [PersonalData]
    public int Birthyear { get; set; }

    [PersonalData]
    public string FirstName { get; set; }

    [PersonalData]
    public string LastName { get; set; }

    [PersonalData]
    public string? UserImage {  get; set; }
}


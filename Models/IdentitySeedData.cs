using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace PartsCatalog.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<AppUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<AppUser>>();
            AppUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new AppUser{
                    UserName = adminUser,
                    Name = "",
                    Surname = "",
                    Country = "",
                    City = "",
                    Street = "",
                    Line1 = "",
                    Zip = "",
                    PhoneNumber = ""
                    
                };
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
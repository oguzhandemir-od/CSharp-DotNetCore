using BlogProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlogProject.Infrastructure.Data
{
    public static class IdentitySeedData
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "Author","Member" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            if (await userManager.FindByEmailAsync("admin@blog.com") == null)
            {
                var adminUser = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@blog.com",
                    FullName = "Baş Yönetici",
                    ImageUrl = "/images/users/admin.png",
                    About = "Sistem Yöneticisi",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "123456");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            if (await userManager.FindByEmailAsync("yazar@blog.com") == null)
            {
                var authorUser = new AppUser
                {
                    UserName = "yazar",
                    Email = "yazar@blog.com",
                    FullName = "Ahmet Yazar",
                    ImageUrl = "/images/users/author.png",
                    About = "Teknoloji Yazarı",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(authorUser, "123456");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(authorUser, "Author");
                }
            }
        }
    }
}

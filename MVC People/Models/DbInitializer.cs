using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_People.Data;

namespace MVC_People.Models
{
    internal class DbInitializer
    {
        internal static async Task Initialize(PeopleDbContext context, UserManager<AppUser> userManager)
        {
            
            string[] roles = new string[] { "Member", "Moderator", "Administrator" };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                if (!context.Roles.Any(r => r.Name == role))
                {
                    await roleStore.CreateAsync(new IdentityRole() { Name = role, NormalizedName = role.ToUpper()});
                }
            }
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new AppUser
                {
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = "Admin123"
                };
                var result = await userManager.CreateAsync(user, user.PasswordHash);
                if (result.Succeeded)
                {
                    var adminUser = await userManager.FindByNameAsync("admin");
                   await userManager.AddToRoleAsync(adminUser, "Administrator");
                   await context.SaveChangesAsync();
                }
                else { Console.WriteLine("--------FAILED TO ADD ADMIN"); }

            }
            context.Database.Migrate();
        }
    }
}

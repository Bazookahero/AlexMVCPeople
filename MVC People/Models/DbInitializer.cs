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
            //var context = serviceProvider.GetService<PeopleDbContext>();
            context.Database.Migrate();
            string[] roles = new string[] { "Member", "Moderator", "Administrator" };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleStore.CreateAsync(new IdentityRole(role));
                }
            }
            foreach (var user in context.Users)
            {
                if(user.UserName == "Bazookahero")
                {
                    AppUser appUser = await userManager.FindByNameAsync("Bazookahero");
                    var result = await userManager.AddToRolesAsync(appUser, roles);
                }
            }
        }
    }
}

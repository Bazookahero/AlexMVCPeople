using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_People.Data;

namespace MVC_People.Models
{
    internal class DbInitializer
    {
        internal static async void Initialize(PeopleDbContext context)
        {
            context.Database.Migrate();
           
        }

    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_People.Models;
using MVC_People.Models.ViewModels;

namespace MVC_People.Data
{
    public class PeopleDbContext : IdentityDbContext<AppUser>
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Person>? People { get; set; }
        public DbSet<City>? Cities { get; set; }
        public DbSet<Country>? Countries { get; set; }
        public DbSet<Language>? Languages { get; set; }
        //public DbSet<LanguagePeople> LanguagePeople { get; set; }

    }
}

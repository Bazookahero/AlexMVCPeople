using Microsoft.EntityFrameworkCore;
using MVC_People.Models;
using MVC_People.Models.ViewModels;

namespace MVC_People.Data
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<LanguagePerson>().HasKey(sc => new { sc.PersonId, sc.LanguageId });
        //}
        public DbSet<Person>? People { get; set; }
        public DbSet<City>? Cities { get; set; }
        public DbSet<Country>? Countries { get; set; }
        public DbSet<Language>? Languages { get; set; }
        public DbSet<LanguagePeople> LanguagePeople { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using MVC_People.Models;

namespace MVC_People.Data
{
    public class LanguageDbContext : DbContext
    {
        public LanguageDbContext(DbContextOptions<LanguageDbContext> options) : base(options)
        { }
        public DbSet<Language>? Languages { get; set; }
    }
}

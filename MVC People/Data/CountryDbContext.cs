using Microsoft.EntityFrameworkCore;
using MVC_People.Models;

namespace MVC_People.Data
{
    public class CountryDbContext : DbContext
    {
        public CountryDbContext(DbContextOptions<CountryDbContext> options) : base(options)
        { }
        public DbSet<Country>? Countries { get; set; }
    }
}

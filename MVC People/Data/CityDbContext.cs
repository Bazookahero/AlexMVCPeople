using Microsoft.EntityFrameworkCore;
using MVC_People.Models;

namespace MVC_People.Data
{
    public class CityDbContext : DbContext
    {
        public CityDbContext(DbContextOptions<CityDbContext> options) : base(options)
        { }
        public DbSet<City>? Cities { get; set; }
    }
}

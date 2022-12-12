using Microsoft.EntityFrameworkCore;
using MVC_People.Data;
using MVC_People.Models.Repo;
using MVC_People.Models.Service;
using MVC_People.Models.People.PeopleRepo;
using MVC_People.Models.People.PeopleService;

namespace MVC_People
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<PeopleDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IPeopleService, PeopleService>();
            //builder.Services.AddScoped<IPeopleRepo, InMemoryPeopleRepo>();
            builder.Services.AddScoped<IPeopleRepo, DbPeopleRepo>();
            builder.Services.AddScoped<ICountryRepo, DbCountryRepo>();
            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<ICityRepo, DbCityRepo>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<ILanguageService, LanguageService>();
            builder.Services.AddScoped<ILanguageRepo, DbLanguageRepo>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
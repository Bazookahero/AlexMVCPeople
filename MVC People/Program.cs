using Microsoft.EntityFrameworkCore;
using MVC_People.Data;
using MVC_People.Models.Repo;
using MVC_People.Models.Service;
using MVC_People.Models.People.PeopleRepo;
using MVC_People.Models.People.PeopleService;
using MVC_People.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

namespace MVC_People
{
    public class Program
    {
        public static async Task Main(string[] args)
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
            builder.Services.AddTransient<UserManager<AppUser>>();
            builder.Services.AddTransient<PeopleDbContext>();

            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<PeopleDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 0;
            });


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

            //builder.Services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.HttpOnly = true;
            //    options.LoginPath = "/Account/Login";
            //});

            app.UseAuthentication();
            app.UseAuthorization();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                UserManager<AppUser> userManager = services.GetService<UserManager<AppUser>>();
                var context = services.GetRequiredService<PeopleDbContext>();
                await DbInitializer.Initialize(context, userManager);
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();
            
        }
    }
}
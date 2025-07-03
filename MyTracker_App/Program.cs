using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyTracker_App.Data;
using MyTracker_App.Models.Auth;

namespace MyTracker_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<MyTrackerDbContext>(options =>
            {
                options.UseSqlite(
                    builder.Configuration.GetConnectionString("DefaultSqlite"));
            });

            builder.Services.AddIdentity<User, MyTrackerRole>(
                options =>
                {
                    options.User.RequireUniqueEmail = true;
                    // that's all for now?? i guess
                })
                .AddEntityFrameworkStores<MyTrackerDbContext>()
                .AddDefaultTokenProviders();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}

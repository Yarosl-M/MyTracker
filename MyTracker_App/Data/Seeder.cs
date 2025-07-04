using Microsoft.AspNetCore.Identity;
using MyTracker_App.Models.Auth;
using MyTracker_App.Models.Domain;

namespace MyTracker_App.Data
{
    public class Seeder
    {
        public static async Task SeedDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider
                .GetRequiredService<MyTrackerDbContext>();
            var role_manager = scope.ServiceProvider
                .GetRequiredService<RoleManager<MyTrackerRole>>();
            var user_manager = scope.ServiceProvider
                .GetRequiredService<UserManager<User>>();
            var logger = scope.ServiceProvider
                .GetRequiredService<ILogger<Seeder>>();

            try
            {
                //logger.LogInformation(string.Empty);
                await context.Database.EnsureCreatedAsync();

                // why can't i use an enum or something
                await AddRoleAsync(role_manager, UserRole.Admin/*.ToString()*/);
                await AddRoleAsync(role_manager, UserRole.Operator/*.ToString()*/);
                await AddRoleAsync(role_manager, UserRole.RegularUser/*.ToString()*/);

                var admin_email = "admin@mytrack.er";
                var admin_pwd = "$2a$04$2rOKAT6uUXhEPZQ92qmC1.QI46YSY7DENUZmchVOsTjBG8VDvnJvS";
                 
                // только если такой записи не найдено
                if (await user_manager.FindByEmailAsync(admin_email) == null)
                {
                    var timestamp = DateTimeOffset.UtcNow;
                    var admin_user = new User()
                    {
                        DisplayName = "Администратор",
                        UserName = admin_email,
                        NormalizedUserName = admin_email.ToUpper(),
                        Email = admin_email,
                        NormalizedEmail = admin_email.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        CreatedAt = timestamp,
                        UpdatedAt = timestamp,
                    };
                    var result = await
                        user_manager.CreateAsync(admin_user,
                        "lostwheretheforestwouldgrow");
                    if (result.Succeeded)
                    {
                        await user_manager.AddToRoleAsync(admin_user,
                            UserRole.Admin.ToString());
                    }
                    else
                    {
                        // error, probably do something
                    }
                }
            }
            catch (Exception ex)
            {
                // also error, probably do something too
            }
        }
        
        public static async Task AddRoleAsync(RoleManager<MyTrackerRole> mgr,
            UserRole role /* ... */) //where TRole : class
        {
            if (!(await mgr.RoleExistsAsync(role.ToString())))
            {
                var result = await mgr.CreateAsync(
                    new MyTrackerRole(role.ToString()));
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException(
                        $"Failed to create role {role.ToString()}:\n{string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}

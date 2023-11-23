using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Sprocket.Enums;
using Sprocket.Models;

namespace Sprocket.Helpers;

public class SeedAdminAccount
{
    private readonly UserContext _context;

    public SeedAdminAccount(UserContext context)
    {
        _context = context;
    }

    public async void SeedAdminUser()
    {
        var adminEmail = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SiteSettings")["AdminEmail"];
        var adminPassword = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("SiteSettings")["AdminPassword"];
        
        var user = new ApplicationUser
        {
            UserName = "Admin",
            NormalizedUserName = "ADMIN",
            Email = adminEmail,
            NormalizedEmail = adminEmail?.ToUpper(),
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString(),
            Role = Role.Admin
        };

        if (!_context.Users.Any(u => u.UserName == user.UserName))
        {
            var password = new PasswordHasher<ApplicationUser>();
            var hashed = password.HashPassword(user, adminPassword);
            user.PasswordHash = hashed;
            var userStore = new UserStore<ApplicationUser>(_context);
            await userStore.CreateAsync(user);
            await userStore.AddToRoleAsync(user, "Admin");
        }

        await _context.SaveChangesAsync();
    }
}
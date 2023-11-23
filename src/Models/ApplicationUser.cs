using Microsoft.AspNetCore.Identity;
using Sprocket.Enums;

namespace Sprocket.Models;

public class ApplicationUser : IdentityUser
{
    public Role Role { get; set; } = Role.User;
}
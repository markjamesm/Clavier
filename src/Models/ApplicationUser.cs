using Microsoft.AspNetCore.Identity;
using Sprocket.Enums;

namespace Sprocket.Models;

public class ApplicationUser : IdentityUser
{
    // Flag based auth 
    public UserType UserFlag { get; set; } 
}
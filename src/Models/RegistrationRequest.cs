using System.ComponentModel.DataAnnotations;
using Sprocket.Enums;

namespace Sprocket.Models;

public class RegistrationRequest
{
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}
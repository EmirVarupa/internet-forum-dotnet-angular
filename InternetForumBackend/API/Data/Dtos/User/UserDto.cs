using System.ComponentModel.DataAnnotations;
using API.Data.Dtos.Roles;
using API.Data.Dtos.UserStatus;
using API.Data.Models;

namespace API.Data.Dtos.User;

public class UserDto
{
    [Required]
    public int StatusId { get; set; }

    [Required]
    public int RoleId { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }

    public string? ImageUrl { get; set; }
}
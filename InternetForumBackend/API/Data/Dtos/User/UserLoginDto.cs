using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos.User;

public class UserLoginDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
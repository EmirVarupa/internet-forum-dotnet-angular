using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Roles;
using API.Data.Dtos.UserStatus;

namespace API.Data.Dtos.User;

/// <summary>
/// Since UserReadAllDto reads all properties, UserReadDto is used to read some of the properties since the rest of them are not necessary,
/// Will be implemented in cases like post creator and post comment creator where we only need the username and the user image
/// </summary>
public class UserReadDto
{
    public int UserId { get; set; }

    public UserStatusReadDto UserStatus { get; set; }

    public RoleReadDto Role { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public string ImageUrl { get; set; }
}
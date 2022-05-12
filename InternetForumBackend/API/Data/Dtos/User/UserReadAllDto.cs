using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Roles;
using API.Data.Dtos.UserStatus;

namespace API.Data.Dtos.User
{
    public class UserReadAllDto
    {
        public int UserId { get; set; }

        public UserStatusReadDto UserStatus { get; set; }

        public RoleReadDto Role { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public string ImageUrl { get; set; }
    }
}

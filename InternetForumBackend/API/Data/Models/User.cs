using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Models
{
    public class User
    {
        public int UserId { get; set; }

        public int StatusId { get; set; }

        public UserStatus UserStatus { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public string Username { get; set; }

        //TODO add salt and password hash
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<Post> Posts { get; set; }

        public User()
        {
            DateCreated = DateTime.Now;
            StatusId = 1;
        }
    }
}

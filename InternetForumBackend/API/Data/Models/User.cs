using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.Data.Models;

public class User
{
    public int UserId { get; set; }

    public int StatusId { get; set; }

    public UserStatus UserStatus { get; set; }

    public int RoleId { get; set; }

    public Role Role { get; set; }

    public string Username { get; set; } = string.Empty;

    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime TokenCreated { get; set; }
    public DateTime TokenExpires { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public DateTime DateCreated { get; set; }

    public string? ImageUrl { get; set; }

    public bool IsArchived { get; set; } = false;

    public ICollection<Post> Posts { get; set; }

    public ICollection<PostComment> PostComments { get; set; }

    public ICollection<UserCommunity> UserCommunities { get; set; }

    public ICollection<UserPostVote> UserPostVotes { get; set; }

    public ICollection<UserPostCommentVote> UserPostCommentVotes { get; set; }


    public User()
    {
        DateCreated = DateTime.Now;
        StatusId = 1;
    }
}
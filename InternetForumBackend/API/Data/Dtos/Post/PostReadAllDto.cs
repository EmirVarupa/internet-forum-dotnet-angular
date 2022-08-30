using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Community;
using API.Data.Dtos.PostVote;
using API.Data.Dtos.User;

namespace API.Data.Dtos.Post;

public class PostReadAllDto
{
    public int PostId { get; set; }

    public CommunityReadDto Community { get; set; }

    public UserReadDto User { get; set; }

    public PostVoteReadDto PostVote { get; set; }

    public string PostTitle { get; set; }

    public string? PostContent { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime DateCreated { get; set; }

    public string? Link { get; set; }

    public bool IsSpoiler { get; set; }

    public int ViewsCount { get; set; }

    
}
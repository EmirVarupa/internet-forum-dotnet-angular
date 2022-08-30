using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Post;
using API.Data.Dtos.PostCommentVote;
using API.Data.Dtos.User;

namespace API.Data.Dtos.PostComment;

public class PostCommentReadAllDto
{
    public int CommentId { get; set; }

    public PostReadAllDto Post { get; set; }

    public UserReadAllDto User { get; set; }

    public string CommentContent { get; set; }

    public DateTime DateCreated { get; set; }
    public PostCommentVoteReadDto PostCommentVote { get; set; }
}
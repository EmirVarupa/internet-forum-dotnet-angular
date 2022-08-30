using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Models;

public class PostComment
{
    public int CommentId { get; set; }

    public int? PostId { get; set; }

    public Post Post { get; set; }

    public int? UserId { get; set; }

    public User User { get; set; }

    public string CommentContent { get; set; }

    public PostCommentVote PostCommentVote { get; set; }

    public DateTime DateCreated { get; set; }

    public PostComment()
    {
        DateCreated = DateTime.Now;
    }
}
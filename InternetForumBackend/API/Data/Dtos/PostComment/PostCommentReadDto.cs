using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Post;
using API.Data.Dtos.PostCommentVote;
using API.Data.Dtos.User;

namespace API.Data.Dtos.PostComment;

/// <summary>
/// Since PostCommentReadAllDto reads all properties, PostCommentReadDto is used to read some of the properties since the rest of them are not necessary,
/// Will be implemented in cases like post comment creator where we only need the username and the user image
/// </summary>
public class PostCommentReadDto
{
    public int CommentId { get; set; }

    public PostReadDto Post { get; set; }

    public UserReadDto User { get; set; }

    public string CommentContent { get; set; }

    public DateTime DateCreated { get; set; }
    public PostCommentVoteReadDto PostCommentVote { get; set; }
}
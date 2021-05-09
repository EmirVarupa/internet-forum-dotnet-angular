using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Post;
using API.Data.Dtos.User;

namespace API.Data.Dtos.PostComment
{
    public class PostCommentReadDto
    {
        public int CommentId { get; set; }

        public PostReadDto Post { get; set; }


        public UserReadDto User { get; set; }

        public string CommentContent { get; set; }

        public DateTime DateCreated { get; set; }
    }
}

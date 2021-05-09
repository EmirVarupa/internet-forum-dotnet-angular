using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos.PostComment
{
    public class PostCommentCreateDto
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string CommentContent { get; set; }
    }
}

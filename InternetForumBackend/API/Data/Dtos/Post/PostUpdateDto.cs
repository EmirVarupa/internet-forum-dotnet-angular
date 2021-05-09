using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos.Post
{
    public class PostUpdateDto
    {
        [Required]
        public int CommunityId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string PostTitle { get; set; }
        [Required]
        public string PostContent { get; set; }

        public string? ImageUrl { get; set; }

        public string? Link { get; set; }

        [Required]
        public bool IsSpoiler { get; set; }
    }
}

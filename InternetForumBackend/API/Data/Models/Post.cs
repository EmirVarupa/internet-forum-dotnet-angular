using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public int CommunityId { get; set; }

        public Community Community { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime DateCreated { get; set; }

        public int Upvotes { get; set; }

        public string? Link { get; set; }

        public bool IsSpoiler { get; set; }

        public int ViewsCount { get; set; }

        public Post()
        {
            DateCreated = DateTime.Now;
            Upvotes = 0;
            ViewsCount = 0;
        }
    }
}

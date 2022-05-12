using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Community;
using API.Data.Dtos.User;

namespace API.Data.Dtos.Post
{
    /// <summary>
    /// Since PostReadAllDto reads all properties, PostReadDto is used to read some of the properties since the rest of them are not necessary,
    /// Will be implemented in cases like list all posts in the community where we only need the post title, community name and the user creator (username and image)
    /// </summary>
    public class PostReadDto
    {
        public int PostId { get; set; }

        public CommunityReadDto Community { get; set; }

        public UserReadDto User { get; set; }

        public string PostTitle { get; set; }

    }
}

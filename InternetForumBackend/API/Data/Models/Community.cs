using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Models
{
    public class Community
    {
        public int CommunityId { get; set; }

        public int CommunityTypeId { get; set; }

        public CommunityType CommunityType { get; set; }

        public string CommunityName { get; set; }

        public string CommunitySummary { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<UserCommunityAdmin> UserCommunityAdmins { get; set; }
    }
}

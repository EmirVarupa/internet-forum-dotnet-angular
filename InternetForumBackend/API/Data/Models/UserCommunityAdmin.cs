using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Models
{
    public class UserCommunityAdmin
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int CommunityId { get; set; }

        public Community Community { get; set; }
    }
}

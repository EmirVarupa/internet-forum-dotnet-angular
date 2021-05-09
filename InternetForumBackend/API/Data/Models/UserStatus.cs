using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Models
{
    public class UserStatus
    {
        /// <summary>
        /// Id of status
        /// </summary>
        public int StatusId { get; set; }
        /// <summary>
        /// Status name
        /// </summary>
        public string StatusName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
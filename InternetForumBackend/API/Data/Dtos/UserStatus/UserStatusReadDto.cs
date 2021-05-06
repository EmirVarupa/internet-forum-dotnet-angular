using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos.UserStatus
{
    public class UserStatusReadDto
    {
        public int StatusId { get; set; }

        public string StatusName { get; set; }
    }
}
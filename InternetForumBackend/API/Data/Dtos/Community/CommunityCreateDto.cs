using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Dtos.Community
{
    public class CommunityCreateDto
    {
        [Required]
        public int CommunityTypeId { get; set; }

        [Required]
        public string CommunityName { get; set; }

        [Required]
        public string CommunitySummary { get; set; }
    }
}

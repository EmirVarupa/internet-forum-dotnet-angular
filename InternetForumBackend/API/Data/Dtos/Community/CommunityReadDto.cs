using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.CommunityType;

namespace API.Data.Dtos.Community;

public class CommunityReadDto
{
    public int CommunityId { get; set; }

    public CommunityTypeReadDto CommunityType { get; set; }

    public string CommunityName { get; set; }

    public string CommunitySummary { get; set; }

    public bool IsArchived { get; set; }
}
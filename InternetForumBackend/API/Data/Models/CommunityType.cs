using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Models;

public class CommunityType
{
    /// <summary>
    /// Id of CommunityType
    /// </summary>
    public int TypeId { get; set; }

    /// <summary>
    /// Community type name
    /// </summary>
    public string TypeName { get; set; }

    public ICollection<Community> Communities { get; set; }
}
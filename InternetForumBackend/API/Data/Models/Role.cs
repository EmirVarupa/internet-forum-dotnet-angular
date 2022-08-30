using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace API.Data.Models;

public class Role
{
    /// <summary>
    /// Id of Role
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Role name
    /// </summary>
    public string RoleName { get; set; }

    public ICollection<User> Users { get; set; }
}
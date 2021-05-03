using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;

namespace API.Data.Repos
{
    public interface IRoleRepo
    {
        Task<IEnumerable<Role>> GetRoleAsync();

        Task<Role> GetRoleByIdAsync(int id);

        Task AddRoleAsync(Role role);

        Task<bool> UpdateRoleAsync(int id, Role role);
    }
}

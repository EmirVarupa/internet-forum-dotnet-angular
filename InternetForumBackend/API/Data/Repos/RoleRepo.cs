using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repos
{
    public class RoleRepo : IRoleRepo
    {
        private readonly ForumContext _context;

        public RoleRepo(ForumContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Role>> GetRoleAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            var roleFromDb = await _context.Roles
                .SingleOrDefaultAsync(us => us.RoleId == id);

            return roleFromDb;
        }

        public async Task AddRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateRoleAsync(int id, Role role)
        {
            var roleFromDb = await GetRoleByIdAsync(id);

            if (roleFromDb == null)
            {
                return false;
            }

            roleFromDb.RoleName = role.RoleName;

            return await _context.SaveChangesAsync() >= 0;
        }
    }
}

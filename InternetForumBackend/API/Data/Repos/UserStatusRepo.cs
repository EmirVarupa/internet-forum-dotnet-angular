using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repos
{
    public class UserStatusRepo : IUserStatusRepo
    {
        private readonly ForumContext _context;

        public UserStatusRepo(ForumContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserStatus>> GetUserStatusAsync()
        {
            return await _context.UserStatuses.ToListAsync();
        }

        public async Task<UserStatus> GetUserStatusByIdAsync(int id)
        {
            var userStatusFromDb = await _context.UserStatuses
                .SingleOrDefaultAsync(us => us.StatusId == id);

            return userStatusFromDb;
        }

        public async Task AddUserStatusAsync(UserStatus userStatus)
        {
            await _context.UserStatuses.AddAsync(userStatus);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateUserStatusAsync(int id, UserStatus userStatus)
        {
            var userStatusFromDb = await GetUserStatusByIdAsync(id);

            if (userStatusFromDb == null)
            {
                return false;
            }

            userStatusFromDb.StatusName = userStatus.StatusName;

            return await _context.SaveChangesAsync() >= 0;
        }
    }
}

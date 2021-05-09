using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly ForumContext _context;

        public UserRepo(ForumContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of users</returns>
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users
                .Include(u => u.UserStatus)
                .Include(u => u.Role)
                .ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var todoFromDb = await _context.Users
                .Include(u => u.UserStatus)
                .Include(u => u.Role)
                .SingleOrDefaultAsync(u => u.UserId == id);

            return todoFromDb;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUserByIdAsync(int id, User user)
        {
            var userFromDb = await GetUserByIdAsync(id);

            if (userFromDb == null)
            {
                return false;
            }

            userFromDb.StatusId = user.StatusId;
            userFromDb.RoleId = user.RoleId;
            userFromDb.Password = user.Password;
            userFromDb.Username = user.Username;
            userFromDb.Email = user.Email;
            userFromDb.FirstName = user.FirstName;
            userFromDb.LastName = user.LastName;
            userFromDb.ImageUrl = user.ImageUrl;

            return await _context.SaveChangesAsync() >= 0;
        }

    }
}

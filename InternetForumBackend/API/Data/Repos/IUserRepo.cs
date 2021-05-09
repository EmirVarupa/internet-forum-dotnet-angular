using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;

namespace API.Data.Repos
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task AddUserAsync(User user);

        Task<User> GetUserByIdAsync(int id);

        Task<bool> UpdateUserByIdAsync(int id, User user);
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;

namespace API.Data.Repos
{
    public interface IUserStatusRepo
    {
        Task<IEnumerable<UserStatus>> GetUserStatusAsync();

        Task<UserStatus> GetUserStatusByIdAsync(int id);

        Task AddUserStatusAsync(UserStatus userStatus);

        Task<bool> UpdateUserStatusAsync(int id, UserStatus userStatus);
    }
}
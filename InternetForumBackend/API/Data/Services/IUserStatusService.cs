using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.UserStatus;
using API.Data.Models;

namespace API.Data.Services
{
    public interface IUserStatusService
    {
        Task<IEnumerable<UserStatus>> GetUserStatusAsync();

        Task<UserStatusReadDto> GetUserStatusByIdAsync(int id);

        Task AddUserStatusAsync(UserStatusCreateDto userStatusCreateDto);

        Task<bool> UpdateUserStatusAsync(int id, UserStatusUpdateDto userStatusUpdateDto);
    }
}
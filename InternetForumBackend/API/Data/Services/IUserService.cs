using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.User;

namespace API.Data.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadAllDto>> GetUsersAsync();

        Task AddUserAsync(UserCreateDto userCreateDto);

        Task<UserReadAllDto> GetUserByIdAsync(int id);

        Task<bool> UpdateUserByIdAsync(int id, UserUpdateDto userUpdateDto);

    }
}

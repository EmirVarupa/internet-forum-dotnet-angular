using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.User;

namespace API.Data.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetUsersAsync();

        Task AddUserAsync(UserCreateDto userCreateDto);

        Task<UserReadDto> GetUserByIdAsync(int id);

        Task<bool> UpdateUserByIdAsync(int id, UserUpdateDto userUpdateDto);

    }
}

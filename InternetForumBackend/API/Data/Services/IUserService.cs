using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Auth;
using API.Data.Dtos.User;
using API.Data.Models;

namespace API.Data.Services;

public interface IUserService
{
    string GetMyName();
    Task<IEnumerable<UserReadAllDto>> GetUsersAsync();

    Task<UserDto> RegisterUserAsync(UserDto userDto);

    Task<AuthResponseDto> LoginUserAsync(UserLoginDto userLoginDto);

    Task<UserReadAllDto> GetUserByUsernameAsync(string username);

    Task<UserReadAllDto> GetUserByUserIdAsync(int userId);

    Task<bool> UpdateUserByIdAsync(int id, UserUpdateDto userUpdateDto);

    Task<AuthResponseDto> RefreshTokenAsync(string refreshToken);
    Task<IEnumerable<UserReadAllDto>> GetUsersFromCommunityAsync(int communityId);

    Task<bool> ArchiveUserByIdAsync(int id);
}
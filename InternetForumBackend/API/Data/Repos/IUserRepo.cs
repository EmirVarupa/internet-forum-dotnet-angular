using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Auth;
using API.Data.Dtos.User;
using API.Data.Models;

namespace API.Data.Repos;

public interface IUserRepo
{
    Task<IEnumerable<User>> GetUsersAsync();

    //TODO: I think I can remove UserDto and just put User, it shouldn't break anything, need to test it later.
    Task<User> RegisterUserAsync(UserDto user);

    Task<AuthResponseDto> LoginUserAsync(UserDto user);

    Task<User> GetUserByUsernameAsync(string id);

    Task<bool> UpdateUserByIdAsync(int id, UserDto user);

    Task<AuthResponseDto> RefreshTokenAsync(string refreshToken);
    Task<User> GetUserByUserIdAsync(int userId);
    Task<IEnumerable<User>> GetUsersFromCommunityAsync(int communityId);

    Task<bool> ArchiveUserByIdAsync(int id);
}
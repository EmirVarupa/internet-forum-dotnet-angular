using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data.Dtos.Auth;
using API.Data.Dtos.User;
using API.Data.Models;
using API.Data.Repos;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace API.Data.Services;

public class UserService : IUserService
{
    private readonly IUserRepo _repo;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IUserRepo repo, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _repo = repo;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetMyName()
    {
        var result = string.Empty;
        if (_httpContextAccessor.HttpContext != null)
            result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        return result;
    }

    public async Task<IEnumerable<UserReadAllDto>> GetUsersAsync()
    {
        var result = await _repo.GetUsersAsync();

        return _mapper.Map<IEnumerable<UserReadAllDto>>(result);
    }


    public async Task<IEnumerable<UserReadAllDto>> GetUsersFromCommunityAsync(int communityId)
    {
        var result = await _repo.GetUsersFromCommunityAsync(communityId);

        return _mapper.Map<IEnumerable<UserReadAllDto>>(result);
    }

    public async Task<UserDto> RegisterUserAsync(UserDto userDto)
    {
        var user = _mapper.Map<UserDto>(userDto);

        await _repo.RegisterUserAsync(user);

        return user;
    }

    public async Task<AuthResponseDto> LoginUserAsync(UserLoginDto userLoginDto)
    {
        var user = _mapper.Map<UserDto>(userLoginDto);

        return await _repo.LoginUserAsync(user);
    }

    public async Task<AuthResponseDto> RefreshTokenAsync(string refreshToken)
    {
        return await _repo.RefreshTokenAsync(refreshToken);
    }

    public async Task<UserReadAllDto> GetUserByUsernameAsync(string username)
    {
        var userFromRepo = await _repo.GetUserByUsernameAsync(username);

        return _mapper.Map<UserReadAllDto>(userFromRepo);
    }

    public async Task<UserReadAllDto> GetUserByUserIdAsync(int userId)
    {
        var userFromRepo = await _repo.GetUserByUserIdAsync(userId);

        return _mapper.Map<UserReadAllDto>(userFromRepo);
    }

    public async Task<bool> UpdateUserByIdAsync(int id, UserUpdateDto userUpdateDto)
    {
        var user = _mapper.Map<UserDto>(userUpdateDto);

        return await _repo.UpdateUserByIdAsync(id, user);
    }

    public async Task<bool> ArchiveUserByIdAsync(int id)
    {
        return await _repo.ArchiveUserByIdAsync(id);
    }
}
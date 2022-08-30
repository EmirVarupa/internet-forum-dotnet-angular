using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using API.Data.Dtos.Auth;
using API.Data.Dtos.User;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Data.Repos;

public class UserRepo : IUserRepo
{
    private readonly ForumContext _context;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserRepo(ForumContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
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
            .Where(u => u.IsArchived == false)
            .ToListAsync();
    }

    public async Task<IEnumerable<User>> GetUsersFromCommunityAsync(int communityId)
    {
        return await _context.Users
            .Include(u => u.UserStatus)
            .Include(u => u.Role)
            .Include(u => u.UserCommunities.Where(uc => uc.CommunityId == communityId))
            .Where(u => u.IsArchived == false)
            .Where(u => u.UserCommunities.Any())
            .ToListAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="user"></param>
    public async Task<User> RegisterUserAsync(UserDto request)
    {
        CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

        var user = new User
        {
            StatusId = request.StatusId,
            RoleId = request.RoleId,
            Username = request.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            ImageUrl = request.ImageUrl
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<AuthResponseDto> LoginUserAsync(UserDto request)
    {
        var user = await _context.Users
            .Include(u => u.UserStatus)
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user == null) return new AuthResponseDto { Message = "User not found." };

        if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            return new AuthResponseDto { Message = "Wrong Password." };

        var token = CreateToken(user);
        var refreshToken = CreateRefreshToken();
        await SetRefreshToken(refreshToken, user);

        return new AuthResponseDto
        {
            Success = true,
            Token = token,
            RefreshToken = refreshToken.Token,
            TokenExpires = refreshToken.Expires
        };
    }

    //TODO: if isArchived show that the user is archived and you can't see posts for this user
    public async Task<User> GetUserByUsernameAsync(string username)
    {
        var todoFromDb = await _context.Users
            .Include(u => u.UserStatus)
            .Include(u => u.Role)
            .SingleOrDefaultAsync(u => u.Username == username);

        return todoFromDb;
    }

    public async Task<User> GetUserByUserIdAsync(int userId)
    {
        var todoFromDb = await _context.Users
            .Include(u => u.UserStatus)
            .Include(u => u.Role)
            .SingleOrDefaultAsync(u => u.UserId == userId);

        return todoFromDb;
    }

   

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<bool> UpdateUserByIdAsync(int id, UserDto user)
    {
        var userFromDb = await GetUserByUserIdAsync(id);

        if (userFromDb == null) return false;

        CreatePasswordHash(user.Password, out var passwordHash, out var passwordSalt);

        userFromDb.StatusId = user.StatusId;
        userFromDb.RoleId = user.RoleId;
        userFromDb.PasswordHash = passwordHash;
        userFromDb.PasswordSalt = passwordSalt;
        userFromDb.Username = user.Username;
        userFromDb.Email = user.Email;
        userFromDb.FirstName = user.FirstName;
        userFromDb.LastName = user.LastName;
        userFromDb.ImageUrl = user.ImageUrl;

        return await _context.SaveChangesAsync() >= 0;
    }

    public async Task<AuthResponseDto> RefreshTokenAsync(string refreshToken)
    {
        var user = await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        if (user == null)
            return new AuthResponseDto { Message = "Invalid Refresh Token" };
        else if (user.TokenExpires < DateTime.Now) return new AuthResponseDto { Message = "Token expired." };

        var token = CreateToken(user);
        var newRefreshToken = CreateRefreshToken();
        await SetRefreshToken(newRefreshToken, user);

        return new AuthResponseDto
        {
            Success = true,
            Token = token,
            RefreshToken = newRefreshToken.Token,
            TokenExpires = newRefreshToken.Expires
        };
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private string CreateToken(User user)
    {
        System.Diagnostics.Debug.WriteLine(user);
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Role, user.Role.RoleName)
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            //expires: DateTime.Now.AddSeconds(30),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    private RefreshToken CreateRefreshToken()
    {
        var refreshToken = new RefreshToken
        {
            Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
            Expires = DateTime.Now.AddDays(7),
            Created = DateTime.Now
        };

        return refreshToken;
    }

    private async Task SetRefreshToken(RefreshToken refreshToken, User user)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = refreshToken.Expires
        };
        _httpContextAccessor?.HttpContext?.Response
            .Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

        user.RefreshToken = refreshToken.Token;
        user.TokenCreated = refreshToken.Created;
        user.TokenExpires = refreshToken.Expires;

        await _context.SaveChangesAsync();
    }


    public async Task<bool> ArchiveUserByIdAsync(int id)
    {
        var userFromDb = _context.Users.FirstOrDefault(p => p.UserId == id);
        if (userFromDb == null) return false;
        userFromDb.IsArchived = true;

        return await _context.SaveChangesAsync() >= 0;
    }
}
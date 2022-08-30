using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Roles;
using API.Data.Models;

namespace API.Data.Services;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetRoleAsync();

    Task<RoleReadDto> GetRoleByIdAsync(int id);

    Task AddRoleAsync(RoleCreateDto roleCreateDto);

    Task<bool> UpdateRoleAsync(int id, RoleUpdateDto roleUpdateDto);
}
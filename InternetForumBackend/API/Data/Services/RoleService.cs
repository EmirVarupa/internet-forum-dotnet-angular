using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Roles;
using API.Data.Models;
using API.Data.Repos;
using AutoMapper;

namespace API.Data.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _repo;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Role>> GetRoleAsync()
        {
            return await _repo.GetRoleAsync();
        }

        public async Task<RoleReadDto> GetRoleByIdAsync(int id)
        {
            var userStatus = await _repo.GetRoleByIdAsync(id);

            if (userStatus == null)
            {
                return null;
            }

            return _mapper.Map<RoleReadDto>(userStatus);
        }

        public async Task AddRoleAsync(RoleCreateDto roleCreateDto)
        {
            var userStatus = _mapper.Map<Role>(roleCreateDto);

            await _repo.AddRoleAsync(userStatus);

        }

        public async Task<bool> UpdateRoleAsync(int id, RoleUpdateDto roleUpdateDto)
        {
            var role = _mapper.Map<Role>(roleUpdateDto);

            return await _repo.UpdateRoleAsync(id, role);
        }
    }
}

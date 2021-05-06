using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.UserStatus;
using API.Data.Models;
using API.Data.Repos;
using AutoMapper;

namespace API.Data.Services
{
    public class UserStatusService : IUserStatusService
    {
        private readonly IUserStatusRepo _repo;
        private readonly IMapper _mapper;

        public UserStatusService(IUserStatusRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserStatus>> GetUserStatusAsync()
        {
            return await _repo.GetUserStatusAsync();
        }

        public async Task<UserStatusReadDto> GetUserStatusByIdAsync(int id)
        {
            var userStatus = await _repo.GetUserStatusByIdAsync(id);

            if (userStatus == null) return null;

            return _mapper.Map<UserStatusReadDto>(userStatus);
        }

        public async Task AddUserStatusAsync(UserStatusCreateDto userStatusCreateDto)
        {
            var userStatus = _mapper.Map<UserStatus>(userStatusCreateDto);

            await _repo.AddUserStatusAsync(userStatus);
        }

        public async Task<bool> UpdateUserStatusAsync(int id, UserStatusUpdateDto userStatusUpdateDto)
        {
            var userStatus = _mapper.Map<UserStatus>(userStatusUpdateDto);

            return await _repo.UpdateUserStatusAsync(id, userStatus);
        }
    }
}
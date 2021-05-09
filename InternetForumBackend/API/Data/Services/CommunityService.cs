using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Community;
using API.Data.Models;
using API.Data.Repos;
using AutoMapper;

namespace API.Data.Services
{
    public class CommunityService : ICommunityService
    {
        private readonly ICommunityRepo _repo;
        private readonly IMapper _mapper;

        public CommunityService(ICommunityRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommunityReadDto>> GetCommunitiesAsync()
        {
            var result = await _repo.GetCommunitiesAsync();

            return _mapper.Map<IEnumerable<CommunityReadDto>>(result);
        }

        public async Task AddCommunityAsync(CommunityCreateDto communityCreateDto)
        {
            var todo = _mapper.Map<Community>(communityCreateDto);

            await _repo.AddCommunityAsync(todo);
        }

        public async Task<CommunityReadDto> GetCommunityByIdAsync(int id)
        {
            var communityFromRepo = await _repo.GetCommunityByIdAsync(id);

            return _mapper.Map<CommunityReadDto>(communityFromRepo);
        }

        public async Task<bool> UpdateCommunityByIdAsync(int id, CommunityUpdateDto communityUpdateDto)
        {
            var todo = _mapper.Map<Community>(communityUpdateDto);

            return await _repo.UpdateCommunityByIdAsync(id, todo);
        }
    }
}

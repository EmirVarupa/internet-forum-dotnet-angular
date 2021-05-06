using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.CommunityType;
using API.Data.Models;
using API.Data.Repos;
using AutoMapper;

namespace API.Data.Services
{
    public class CommunityTypeService : ICommunityTypeService
    {
        private readonly ICommunityTypeRepo _repo;
        private readonly IMapper _mapper;
        public CommunityTypeService(ICommunityTypeRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CommunityType>> GetCommunityTypeAsync()
        {
            return await _repo.GetCommunityTypeAsync();
        }

        public async Task<CommunityTypeReadDto> GetCommunityTypeByIdAsync(int id)
        {
            var communityType = await _repo.GetCommunityTypeByIdAsync(id);

            if (communityType == null)
            {
                return null;
            }

            return _mapper.Map<CommunityTypeReadDto>(communityType);
        }

        public async Task AddCommunityTypeAsync(CommunityTypeCreateDto communityTypeCreateDto)
        {
            var communityType = _mapper.Map<CommunityType>(communityTypeCreateDto);

            await _repo.AddCommunityTypeAsync(communityType);

        }

        public async Task<bool> UpdateCommunityTypeAsync(int id, CommunityTypeUpdateDto communityTypeUpdateDto)
        {
            var communityType = _mapper.Map<CommunityType>(communityTypeUpdateDto);

            return await _repo.UpdateCommunityTypeAsync(id, communityType);
        }
    }
}

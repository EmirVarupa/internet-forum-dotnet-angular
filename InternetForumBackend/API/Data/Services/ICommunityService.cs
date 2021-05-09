using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Community;

namespace API.Data.Services
{
    public interface ICommunityService
    {
        Task<IEnumerable<CommunityReadDto>> GetCommunitiesAsync();

        Task AddCommunityAsync(CommunityCreateDto communityCreateDto);

        Task<CommunityReadDto> GetCommunityByIdAsync(int id);

        Task<bool> UpdateCommunityByIdAsync(int id, CommunityUpdateDto communityUpdateDto);
    }
}

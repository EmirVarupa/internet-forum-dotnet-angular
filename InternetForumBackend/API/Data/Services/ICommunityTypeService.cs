using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.CommunityType;
using API.Data.Models;

namespace API.Data.Services
{
    public interface ICommunityTypeService
    {
        Task<IEnumerable<CommunityType>> GetCommunityTypeAsync();

        Task<CommunityTypeReadDto> GetCommunityTypeByIdAsync(int id);

        Task AddCommunityTypeAsync(CommunityTypeCreateDto communityTypeCreateDto);

        Task<bool> UpdateCommunityTypeAsync(int id, CommunityTypeUpdateDto communityTypeUpdateDto);
    }
}
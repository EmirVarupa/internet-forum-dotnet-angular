using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;

namespace API.Data.Repos
{
    public interface ICommunityTypeRepo
    {
        Task<IEnumerable<CommunityType>> GetCommunityTypeAsync();

        Task<CommunityType> GetCommunityTypeByIdAsync(int id);

        Task AddCommunityTypeAsync(CommunityType communityType);

        Task<bool> UpdateCommunityTypeAsync(int id, CommunityType communityType);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;

namespace API.Data.Repos;

public interface ICommunityRepo
{
    Task<IEnumerable<Community>> GetCommunitiesAsync();

    Task AddCommunityAsync(Community commmunity);

    Task<Community> GetCommunityByIdAsync(int id);

    Task<bool> UpdateCommunityByIdAsync(int id, Community commmunity);

    Task<bool> ArchiveCommunityByIdAsync(int id);
}
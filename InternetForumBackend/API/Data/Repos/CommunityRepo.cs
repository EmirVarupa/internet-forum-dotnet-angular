using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repos
{
    public class CommunityRepo : ICommunityRepo
    {
        private readonly ForumContext _context;

        public CommunityRepo(ForumContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of communities</returns>
        public async Task<IEnumerable<Community>> GetCommunitiesAsync()
        {
            return await _context.Communities
                .Include(c => c.CommunityType)
                .ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="community"></param>
        public async Task AddCommunityAsync(Community community)
        {
            await _context.Communities.AddAsync(community);
            await _context.SaveChangesAsync();
        }

        public async Task<Community> GetCommunityByIdAsync(int id)
        {
            var todoFromDb = await _context.Communities
                .Include(c => c.CommunityType)
                .SingleOrDefaultAsync(c => c.CommunityId == id);

            return todoFromDb;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="community"></param>
        /// <returns></returns>
        public async Task<bool> UpdateCommunityByIdAsync(int id, Community community)
        {
            var communityFromDb = await GetCommunityByIdAsync(id);

            if (communityFromDb == null)
            {
                return false;
            }

            communityFromDb.CommunityName = community.CommunityName;
            communityFromDb.CommunitySummary = community.CommunitySummary;
            communityFromDb.CommunityTypeId = community.CommunityTypeId;

            return await _context.SaveChangesAsync() >= 0;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repos
{
    public class CommunityTypeRepo : ICommunityTypeRepo
    {
        private readonly ForumContext _context;

        public CommunityTypeRepo(ForumContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CommunityType>> GetCommunityTypeAsync()
        {
            return await _context.CommunityTypes.ToListAsync();
        }

        public async Task<CommunityType> GetCommunityTypeByIdAsync(int id)
        {
            var communityTypeFromDb = await _context.CommunityTypes
                .SingleOrDefaultAsync(us => us.TypeId == id);

            return communityTypeFromDb;
        }

        public async Task AddCommunityTypeAsync(CommunityType communityType)
        {
            await _context.CommunityTypes.AddAsync(communityType);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCommunityTypeAsync(int id, CommunityType communityType)
        {
            var communityTypeFromDb = await GetCommunityTypeByIdAsync(id);

            if (communityTypeFromDb == null) return false;

            communityTypeFromDb.TypeName = communityType.TypeName;

            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
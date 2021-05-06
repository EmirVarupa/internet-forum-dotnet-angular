using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repos
{
    public class TagRepo : ITagRepo
    {
        private readonly ForumContext _context;

        public TagRepo(ForumContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tag>> GetTagAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag> GetTagByIdAsync(int id)
        {
            var tagFromDb = await _context.Tags
                .SingleOrDefaultAsync(t => t.TagId == id);

            return tagFromDb;
        }

        public async Task AddTagAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateTagAsync(int id, Tag tag)
        {
            var tagFromDb = await GetTagByIdAsync(id);

            if (tagFromDb == null) return false;

            tagFromDb.TagName = tag.TagName;

            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;

namespace API.Data.Repos;

public interface ITagRepo
{
    Task<IEnumerable<Tag>> GetTagAsync();

    Task<Tag> GetTagByIdAsync(int id);

    Task AddTagAsync(Tag tag);

    Task<bool> UpdateTagAsync(int id, Tag tag);
}
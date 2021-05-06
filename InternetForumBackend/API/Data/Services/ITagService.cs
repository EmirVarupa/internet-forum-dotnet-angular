using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Tag;
using API.Data.Models;

namespace API.Data.Services
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetTagAsync();

        Task<TagReadDto> GetTagByIdAsync(int id);

        Task AddTagAsync(TagCreateDto tagCreateDto);

        Task<bool> UpdateTagAsync(int id, TagUpdateDto tagUpdateDto);
    }
}
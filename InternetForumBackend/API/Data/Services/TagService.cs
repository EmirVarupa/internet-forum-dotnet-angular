using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Dtos.Tag;
using API.Data.Models;
using API.Data.Repos;
using AutoMapper;

namespace API.Data.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepo _repo;
        private readonly IMapper _mapper;

        public TagService(ITagRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Tag>> GetTagAsync()
        {
            return await _repo.GetTagAsync();
        }

        public async Task<TagReadDto> GetTagByIdAsync(int id)
        {
            var tag = await _repo.GetTagByIdAsync(id);

            if (tag == null) return null;

            return _mapper.Map<TagReadDto>(tag);
        }

        public async Task AddTagAsync(TagCreateDto tagCreateDto)
        {
            var tag = _mapper.Map<Tag>(tagCreateDto);

            await _repo.AddTagAsync(tag);
        }

        public async Task<bool> UpdateTagAsync(int id, TagUpdateDto tagUpdateDto)
        {
            var tag = _mapper.Map<Tag>(tagUpdateDto);

            return await _repo.UpdateTagAsync(id, tag);
        }
    }
}
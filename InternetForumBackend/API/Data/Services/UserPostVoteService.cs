using API.Data.Dtos.UserPostVote;
using API.Data.Models;
using API.Data.Repos;
using AutoMapper;

namespace API.Data.Services;

public class UserPostVoteService : IUserPostVoteService
{
    private readonly IUserPostVoteRepo _repo;
    private readonly IMapper _mapper;

    public UserPostVoteService(IUserPostVoteRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserPostVoteReadDto>> GetUserPostVotesByUserIdAsync(int userId)
    {
        var userPostVoteFromRepo = await _repo.GetUserPostVotesByUserIdAsync(userId);

        return _mapper.Map<IEnumerable<UserPostVoteReadDto>>(userPostVoteFromRepo);
    }

    public async Task<IEnumerable<UserPostVoteReadDto>> GetUserPostVotesByPostIdAsync(int userId)
    {
        var userPostVoteFromRepo = await _repo.GetUserPostVotesByPostIdAsync(userId);

        return _mapper.Map<IEnumerable<UserPostVoteReadDto>>(userPostVoteFromRepo);
    }

    public async Task<IEnumerable<UserPostVoteReadDto>> GetUserPostVotesByPostAndUserIdAsync(int userId, int postId)
    {
        var userPostVoteFromRepo = await _repo.GetUserPostVotesByPostAndUserIdAsync(userId, postId);

        return _mapper.Map<IEnumerable<UserPostVoteReadDto>>(userPostVoteFromRepo);
    }

    public async Task AddUserPostVoteAsync(UserPostVoteDto userPostVoteDto)
    {
        var userPostVote = _mapper.Map<UserPostVote>(userPostVoteDto);

        await _repo.AddUserPostVoteAsync(userPostVote);
    }

    public async Task<int?> IncrementOrDecrementPostVoteWithUserIdAsync(UserPostVoteDto userPostVoteDto)
    {
        var userPostVote = _mapper.Map<UserPostVote>(userPostVoteDto);

        return await _repo.IncrementOrDecrementPostVoteWithUserIdAsync(userPostVote);
    }
}
using API.Data.Dtos.UserPostCommentVote;
using API.Data.Dtos.UserPostVote;
using API.Data.Models;
using API.Data.Repos;
using AutoMapper;

namespace API.Data.Services;
public class UserPostCommentVoteService : IUserPostCommentVoteService
{
    private readonly IUserPostCommentVoteRepo _repo;
    private readonly IMapper _mapper;

    public UserPostCommentVoteService(IUserPostCommentVoteRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserPostCommentVoteReadDto>> GetUserPostCommentVotesByUserIdAsync(int userId)
    {
        var userPostVoteFromRepo = await _repo.GetUserPostCommentVotesByUserIdAsync(userId);

        return _mapper.Map<IEnumerable<UserPostCommentVoteReadDto>>(userPostVoteFromRepo);
    }

    public async Task<IEnumerable<UserPostCommentVoteReadDto>> GetUserPostCommentVotesByPostCommentIdAsync(int postCommentId)
    {
        var userPostCommentVoteFromRepo = await _repo.GetUserPostCommentVotesByPostCommentIdAsync(postCommentId);

        return _mapper.Map<IEnumerable<UserPostCommentVoteReadDto>>(userPostCommentVoteFromRepo);
    }

    public async Task<IEnumerable<UserPostCommentVoteReadDto>> GetUserPostCommentVotesByPostCommentAndUserIdAsync(int userId, int postId)
    {
        var userPostCommentVoteFromRepo = await _repo.GetUserPostCommentVotesByPostCommentAndUserIdAsync(userId, postId);

        return _mapper.Map<IEnumerable<UserPostCommentVoteReadDto>>(userPostCommentVoteFromRepo);
    }

    public async Task AddUserPostCommentVoteAsync(UserPostCommentVoteDto userPostCommentVoteDto)
    {
        var userPostCommentVote = _mapper.Map<UserPostCommentVote>(userPostCommentVoteDto);

        await _repo.AddUserPostCommentVoteAsync(userPostCommentVote);
    }

    public async Task<int?> IncrementOrDecrementPostCommentVoteWithUserIdAsync(UserPostCommentVoteDto userPostCommentVoteDto)
    {
        var userPostCommentVote = _mapper.Map<UserPostCommentVote>(userPostCommentVoteDto);

        return await _repo.IncrementOrDecrementPostCommentVoteWithUserIdAsync(userPostCommentVote);
    }
}

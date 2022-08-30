using API.Data.Dtos.Community;
using API.Data.Dtos.User;

namespace API.Data.Dtos.UserCommunity;

public class UserCommunityReadDto
{
    public int UserId { get; set; }

    public int CommunityId { get; set; }

    public CommunityReadDto Community { get; set; }

    public bool IsJoined { get; set; }

    public string Role { get; set; }
}
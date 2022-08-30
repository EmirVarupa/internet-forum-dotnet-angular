namespace API.Data.Dtos.UserCommunity;

public class UserCommunityCreateDto
{
    public int UserId { get; set; }

    public int CommunityId { get; set; }

    public bool IsJoined { get; set; }
}
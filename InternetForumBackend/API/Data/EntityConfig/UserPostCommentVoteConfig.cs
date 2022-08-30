using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.EntityConfig;

public class UserPostCommentVoteConfig : IEntityTypeConfiguration<UserPostCommentVote>
{
    public void Configure(EntityTypeBuilder<UserPostCommentVote> builder)
    {
        builder.HasKey(upv => new { upv.UserId, upv.PostCommentVoteId });

        builder.HasOne(upv => upv.User)
            .WithMany(p => p.UserPostCommentVotes)
            .HasForeignKey(upv => upv.UserId);

        builder.HasOne(upv => upv.PostCommentVote)
            .WithMany(p => p.UserPostCommentVotes)
            .HasForeignKey(upv => upv.PostCommentVoteId);

        builder.ToTable("Users_PostCommentVotes");
    }
}
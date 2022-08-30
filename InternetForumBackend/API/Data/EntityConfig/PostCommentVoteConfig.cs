using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.EntityConfig;

public class PostCommentVoteConfig : IEntityTypeConfiguration<PostCommentVote>
{
    public void Configure(EntityTypeBuilder<PostCommentVote> builder)
    {
        builder.HasKey(pv => pv.VoteId);

        builder.HasOne(pv => pv.PostComment)
            .WithOne(p => p.PostCommentVote)
            .HasForeignKey<PostCommentVote>(pv => pv.CommentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

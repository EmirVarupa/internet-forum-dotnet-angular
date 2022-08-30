using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.EntityConfig;

public class PostVoteConfig : IEntityTypeConfiguration<PostVote>
{
    public void Configure(EntityTypeBuilder<PostVote> builder)
    {
        builder.HasKey(pv => pv.VoteId);

        /*
        builder.HasOne(p => p.Post)
            .WithOne(u => u.PostVote)
            .HasForeignKey<Post>(p => p.PostId)
            .OnDelete(DeleteBehavior.Restrict);
        */
        builder.HasOne(pv => pv.Post)
            .WithOne(p => p.PostVote)
            .HasForeignKey<PostVote>(pv => pv.PostId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.EntityConfig;

public class UserPostVoteConfig : IEntityTypeConfiguration<UserPostVote>
{
    public void Configure(EntityTypeBuilder<UserPostVote> builder)
    {
        builder.HasKey(upv => new { upv.UserId, upv.PostVoteId });

        builder.HasOne(upv => upv.User)
            .WithMany(p => p.UserPostVotes)
            .HasForeignKey(upv => upv.UserId);

        builder.HasOne(upv => upv.PostVote)
            .WithMany(p => p.UserPostVotes)
            .HasForeignKey(upv => upv.PostVoteId);

        builder.ToTable("Users_PostVotes");
    }
}
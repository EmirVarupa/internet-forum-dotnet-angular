using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.EntityConfig;

public class UserCommunityConfig : IEntityTypeConfiguration<UserCommunity>
{
    public void Configure(EntityTypeBuilder<UserCommunity> builder)
    {
        builder.HasKey(usc => new { usc.CommunityId, usc.UserId });

        builder.HasOne(usc => usc.User)
            .WithMany(u => u.UserCommunities)
            .HasForeignKey(usc => usc.UserId);

        builder.HasOne(usc => usc.Community)
            .WithMany(c => c.UserCommunities)
            .HasForeignKey(usc => usc.CommunityId);

        builder.ToTable("Users_Communities");
    }
}
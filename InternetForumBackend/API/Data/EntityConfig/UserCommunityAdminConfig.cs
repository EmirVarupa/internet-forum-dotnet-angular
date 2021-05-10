using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.EntityConfig
{
    public class UserCommunityAdminConfig : IEntityTypeConfiguration<UserCommunityAdmin>
    {
        public void Configure(EntityTypeBuilder<UserCommunityAdmin> builder)
        {
            builder.HasKey(usc => new { usc.CommunityId, usc.UserId });

            builder.ToTable("Users_CommunityAdmin");
        }
    }
}

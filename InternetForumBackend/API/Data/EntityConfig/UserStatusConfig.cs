using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.EntityConfig;

public class UserStatusConfig : IEntityTypeConfiguration<UserStatus>
{
    public void Configure(EntityTypeBuilder<UserStatus> builder)
    {
        builder.HasKey(usc => usc.StatusId);

        builder.Property(usc => usc.StatusName)
            .IsRequired()
            .HasMaxLength(50);
    }
}
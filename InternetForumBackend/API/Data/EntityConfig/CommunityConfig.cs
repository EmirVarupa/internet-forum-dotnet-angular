using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.EntityConfig;

public class CommunityConfig : IEntityTypeConfiguration<Community>
{
    public void Configure(EntityTypeBuilder<Community> builder)
    {
        builder.HasKey(c => c.CommunityId);

        builder.Property(c => c.CommunityName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.CommunitySummary)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne(c => c.CommunityType)
            .WithMany(ct => ct.Communities)
            .HasForeignKey(c => c.CommunityTypeId);
    }
}
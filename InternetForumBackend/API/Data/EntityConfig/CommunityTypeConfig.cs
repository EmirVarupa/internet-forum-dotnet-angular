using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.EntityConfig
{
    public class CommunityTypeConfig : IEntityTypeConfiguration<CommunityType>
    {
        public void Configure(EntityTypeBuilder<CommunityType> builder)
        {
            builder.HasKey(ct => ct.TypeId);

            builder.Property(ct => ct.TypeName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

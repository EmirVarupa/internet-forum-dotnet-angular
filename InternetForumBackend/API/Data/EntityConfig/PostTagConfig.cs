using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.EntityConfig
{
    public class PostTagConfig : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.HasKey(p => new {p.PostId, p.TagId});
        }
    }
}

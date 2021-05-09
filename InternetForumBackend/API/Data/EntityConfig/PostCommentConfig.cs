using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.EntityConfig
{
    public class PostCommentConfig : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            builder.HasKey(p => p.CommentId);

            builder.Property(p => p.CommentContent)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(p => p.Post)
                .WithMany(c => c.PostComments)
                .HasForeignKey(p => p.PostId);

            builder.HasOne(p => p.User)
                .WithMany(r => r.PostComments)
                .HasForeignKey(p => p.UserId);
        }
    }
}

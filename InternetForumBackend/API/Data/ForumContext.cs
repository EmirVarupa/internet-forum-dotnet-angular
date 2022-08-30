﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.EntityConfig;
using API.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ForumContext : DbContext
{
    public DbSet<UserStatus> UserStatuses { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<CommunityType> CommunityTypes { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Community> Communities { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<PostComment> PostComments { get; set; }

    public DbSet<PostTag> PostTags { get; set; }

    public DbSet<PostVote> PostVotes { get; set; }

    public DbSet<PostCommentVote> PostCommentVotes { get; set; }

    public DbSet<UserCommunity> UserCommunities { get; set; }

    public DbSet<UserPostVote> UserPostVotes { get; set; }

    public DbSet<UserPostCommentVote> UserPostCommentVotes { get; set; }

    public ForumContext(DbContextOptions<ForumContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserStatusConfig());

        modelBuilder.ApplyConfiguration(new RoleConfig());

        modelBuilder.ApplyConfiguration(new TagConfig());

        modelBuilder.ApplyConfiguration(new CommunityTypeConfig());

        modelBuilder.ApplyConfiguration(new UserConfig());

        modelBuilder.ApplyConfiguration(new CommunityConfig());

        modelBuilder.ApplyConfiguration(new PostConfig());

        modelBuilder.ApplyConfiguration(new PostCommentConfig());

        modelBuilder.ApplyConfiguration(new PostTagConfig());

        modelBuilder.ApplyConfiguration(new UserCommunityConfig());

        modelBuilder.ApplyConfiguration(new PostVoteConfig());

        modelBuilder.ApplyConfiguration(new PostCommentVoteConfig());

        modelBuilder.ApplyConfiguration(new UserPostVoteConfig());

        modelBuilder.ApplyConfiguration(new UserCommunityConfig());

        modelBuilder.ApplyConfiguration(new UserPostCommentVoteConfig());

        base.OnModelCreating(modelBuilder);
    }
}
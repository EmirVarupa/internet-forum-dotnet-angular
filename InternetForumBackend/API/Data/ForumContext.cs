using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.EntityConfig;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ForumContext : DbContext
    {
        public DbSet<UserStatus> UserStatuses { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserStatusConfig());

            modelBuilder.ApplyConfiguration(new RoleConfig());

            modelBuilder.ApplyConfiguration(new TagConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace forum.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserBoard>().HasKey(x => new { x.UserId, x.BoardId });
            builder.Entity<UserRelations>().HasKey(x => new { x.CreatorId, x.TargetId });

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.TaggingOthers)
                .WithOne(ur => ur.Creator)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.TaggedBy)
                .WithOne(ur => ur.Target)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserRelations>()
                .HasOne(ur => ur.Creator)
                .WithMany(u => u.TaggingOthers)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<UserRelations>()
                .HasOne(ur => ur.Target)
                .WithMany(u => u.TaggedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasMany(v => v.Comments)
                .WithOne(c => c.ParentComment)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Comment>()
                .HasOne(c => c.ParentComment)
                .WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .HasMany(v => v.Comments)
                .WithOne(c => c.ParentPost)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Comment>()
                .HasOne(c => c.ParentPost)
                .WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Vote>()
                .HasOne(v => v.Voter)
                .WithMany(u => u.Votes)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        
        public DbSet<UserRelations> UserRelationss { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<UserBoard> UserBoards { get; set; }
    }
}

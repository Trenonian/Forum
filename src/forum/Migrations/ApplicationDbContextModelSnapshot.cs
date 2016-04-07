using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using forum.Models;

namespace forum.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("forum.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("CreatorId");

                    b.Property<int>("CreatorId1");

                    b.Property<int>("CreatorId2");

                    b.Property<int>("CreatorId3");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("TargetId");

                    b.Property<int>("TargetId1");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<int>("UserId");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("VoterId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("forum.Models.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("forum.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CommentId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<int>("CreatorId");

                    b.Property<bool>("Deleted");

                    b.Property<int>("ParentBoardId");

                    b.Property<int>("ParentId");

                    b.Property<int?>("PostId");

                    b.Property<int>("Score");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("forum.Models.Edit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CommentId");

                    b.Property<string>("Content");

                    b.Property<int>("ParentId");

                    b.Property<int?>("PostId");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("forum.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<int>("CreatorId");

                    b.Property<bool>("Deleted");

                    b.Property<int>("ParentBoardId");

                    b.Property<int>("Score");

                    b.Property<string>("Title");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("forum.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("CreatorId");

                    b.Property<int>("TargetId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("forum.Models.UserBoard", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("BoardId");

                    b.Property<int>("Id");

                    b.HasKey("UserId", "BoardId");
                });

            modelBuilder.Entity("forum.Models.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CommentId");

                    b.Property<int?>("PostId");

                    b.Property<int>("TargetId");

                    b.Property<int?>("VoteableId");

                    b.Property<int>("VoterId");

                    b.Property<bool>("isUpVote");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("forum.Models.Voteable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<int>("CreatorId");

                    b.Property<bool>("Deleted");

                    b.Property<int>("ParentBoardId");

                    b.Property<int>("Score");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("forum.Models.Comment", b =>
                {
                    b.HasOne("forum.Models.Comment")
                        .WithMany()
                        .HasForeignKey("CommentId");

                    b.HasOne("forum.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .HasPrincipalKey("CreatorId1");

                    b.HasOne("forum.Models.Board")
                        .WithMany()
                        .HasForeignKey("ParentBoardId");

                    b.HasOne("forum.Models.Voteable")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("forum.Models.Post")
                        .WithMany()
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("forum.Models.Edit", b =>
                {
                    b.HasOne("forum.Models.Comment")
                        .WithMany()
                        .HasForeignKey("CommentId");

                    b.HasOne("forum.Models.Voteable")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("forum.Models.Post")
                        .WithMany()
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("forum.Models.Post", b =>
                {
                    b.HasOne("forum.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .HasPrincipalKey("CreatorId2");

                    b.HasOne("forum.Models.Board")
                        .WithMany()
                        .HasForeignKey("ParentBoardId");
                });

            modelBuilder.Entity("forum.Models.Tag", b =>
                {
                    b.HasOne("forum.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .HasPrincipalKey("CreatorId3");

                    b.HasOne("forum.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .HasPrincipalKey("TargetId1");
                });

            modelBuilder.Entity("forum.Models.UserBoard", b =>
                {
                    b.HasOne("forum.Models.Board")
                        .WithMany()
                        .HasForeignKey("BoardId");

                    b.HasOne("forum.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasPrincipalKey("UserId");
                });

            modelBuilder.Entity("forum.Models.Vote", b =>
                {
                    b.HasOne("forum.Models.Comment")
                        .WithMany()
                        .HasForeignKey("CommentId");

                    b.HasOne("forum.Models.Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("forum.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .HasPrincipalKey("TargetId");

                    b.HasOne("forum.Models.Voteable")
                        .WithMany()
                        .HasForeignKey("VoteableId");

                    b.HasOne("forum.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("VoterId")
                        .HasPrincipalKey("VoterId");
                });

            modelBuilder.Entity("forum.Models.Voteable", b =>
                {
                    b.HasOne("forum.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .HasPrincipalKey("CreatorId");

                    b.HasOne("forum.Models.Board")
                        .WithMany()
                        .HasForeignKey("ParentBoardId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("forum.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("forum.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("forum.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}